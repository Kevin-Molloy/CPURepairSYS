using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.Exceptions;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Tests.Unit;

public sealed class RepairLifecycleTests
{
    private static Repair CreateRepair() => Repair.CreateLogged(
        new RepairId(1), "Replace CPU", "CPU", new CustomerId(1), new DateOnly(2026, 10, 15));

    [Fact]
    public void EstimateApprovalAndCompletionFollowTheStateMachine()
    {
        var repair = CreateRepair();
        repair.CreateEstimate(new[] { RepairItem.Create(new PartId(7), new Money(25.50m), 2) });
        repair.Approve(new DateOnly(2026, 10, 16));
        repair.Complete(new DateOnly(2026, 10, 17));

        Assert.Equal(RepairStatus.Completed, repair.Status);
        Assert.Equal(new Money(51.00m), repair.Price);
        Assert.Equal(new DateOnly(2026, 10, 17), repair.CompletedDate);
    }

    [Fact]
    public void InvalidLifecycleTransitionIsRejected()
    {
        var repair = CreateRepair();

        Assert.Throws<InvalidDomainOperationException>(() => repair.Complete(DateOnly.FromDateTime(DateTime.UtcNow)));
        Assert.Equal(RepairStatus.Logged, repair.Status);
    }

    [Fact]
    public void CancelledRepairIsTerminal()
    {
        var repair = CreateRepair();
        repair.Cancel(new DateOnly(2026, 10, 15));

        Assert.Equal(RepairStatus.Cancelled, repair.Status);
        Assert.Throws<InvalidDomainOperationException>(() => repair.CreateEstimate(new[] { RepairItem.Create(new PartId(7), new Money(1), 1) }));
    }

    [Fact]
    public void DuplicateEstimatePartsAreRejected()
    {
        var repair = CreateRepair();
        var item = RepairItem.Create(new PartId(7), new Money(10), 1);

        Assert.Throws<InvalidDomainOperationException>(() => repair.CreateEstimate(new[] { item, item }));
        Assert.Equal(Money.Zero, repair.Price);
    }
}

public sealed class PartInventoryTests
{
    [Fact]
    public void AllocationDecrementsStockAndMarksPartOutOfStockAtZero()
    {
        var part = Part.Create(new PartId(1), "CPU", new Money(100), 2, "CPU");

        part.Allocate(2);

        Assert.Equal(0, part.Quantity);
        Assert.Equal(PartStatus.OutOfStock, part.Status);
    }

    [Fact]
    public void AllocationCannotExceedStockOrUseDiscontinuedPart()
    {
        var part = Part.Create(new PartId(1), "CPU", new Money(100), 2, "CPU");
        Assert.Throws<InvalidDomainOperationException>(() => part.Allocate(3));

        part.Discontinue();
        Assert.Throws<InvalidDomainOperationException>(() => part.Allocate(1));
    }

    [Fact]
    public void MoneyAndPhoneValuesAreValidatedAndTyped()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Money(-1));
        Assert.Throws<ArgumentException>(() => new PhoneNumber("01-234"));
        Assert.Equal(new PhoneNumber("01234"), new PhoneNumber("01234"));
    }

    [Fact]
    public void CustomerAndPartInputValidatorsRejectInvalidFields()
    {
        Assert.Throws<ArgumentException>(() =>
            Customer.Create(new CustomerId(1), "", "Smith", new PhoneNumber("087123"), "alex@example.com"));
        Assert.Throws<ArgumentException>(() =>
            Part.Create(new PartId(1), "", new Money(10), 1, "PROC"));
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Money(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            RepairItem.Create(new PartId(1), new Money(10), 0));
        Assert.Equal(0, new CustomerId(0).Value);
        Assert.Equal(0, new PartId(0).Value);
        Assert.Equal(0, new RepairId(0).Value);
    }
}
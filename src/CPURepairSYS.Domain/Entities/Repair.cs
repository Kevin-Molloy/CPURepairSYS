using CPURepairSYS.Domain.Exceptions;
using CPURepairSYS.Domain.States;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Domain.Entities;

public enum RepairStatus
{
    Logged,
    Estimated,
    Approved,
    Completed,
    Cancelled
}

public sealed class Repair
{
    private Repair()
    {
        Description = null!;
        RepairTypeCode = null!;
        state = LoggedState.Instance;
        persistedStatus = RepairStatus.Logged;
    }

    private readonly List<RepairItem> items = new();
    private IRepairState state;
    private RepairStatus persistedStatus;

    private Repair(RepairId id, string description, string repairTypeCode, CustomerId customerId, DateOnly? startDate)
    {
        Id = id;
        Description = ValidateDescription(description);
        RepairTypeCode = ValidateCode(repairTypeCode, nameof(repairTypeCode), 8);
        CustomerId = customerId;
        StartDate = startDate;
        Price = Money.Zero;
        state = LoggedState.Instance;
        persistedStatus = RepairStatus.Logged;
    }

    public RepairId Id { get; private set; }
    public string Description { get; }
    public string RepairTypeCode { get; }
    public CustomerId CustomerId { get; }
    public DateOnly? StartDate { get; }
    public DateOnly? ApprovedDate { get; private set; }
    public DateOnly? CompletedDate { get; private set; }
    public DateOnly? CancelledDate { get; private set; }
    public Money? Price { get; private set; }
    public RepairStatus Status => PersistedStatus;
    public RepairStatus EffectiveStatus => PersistedStatus;
    public RepairStatus PersistedStatus
    {
        get => persistedStatus;
        set
        {
            persistedStatus = value;
            state = CreateState(value);
        }
    }
    public IReadOnlyList<RepairItem> Items => items;

    public static Repair CreateLogged(RepairId id, string description, string repairTypeCode, CustomerId customerId, DateOnly startDate) =>
        new(id, description, repairTypeCode, customerId, startDate);

    internal static Repair Rehydrate(
        RepairId id,
        string description,
        string repairTypeCode,
        CustomerId customerId,
        DateOnly? startDate,
        RepairStatus status,
        Money? price,
        DateOnly? approvedDate,
        DateOnly? completedDate,
        DateOnly? cancelledDate,
        IEnumerable<RepairItem> estimateItems)
    {
        var materialisedItems = estimateItems?.ToList() ?? new List<RepairItem>();
        var effectiveStatus = status == RepairStatus.Logged
            && price.HasValue
            && price.Value.Amount > 0
            ? RepairStatus.Estimated
            : status;
        var repair = new Repair(id, description, repairTypeCode, customerId, startDate)
        {
            Price = price ?? Money.Zero,
            ApprovedDate = approvedDate,
            CompletedDate = completedDate,
            CancelledDate = cancelledDate
        };
        repair.items.AddRange(materialisedItems);
        repair.state = effectiveStatus switch
        {
            RepairStatus.Logged => LoggedState.Instance,
            RepairStatus.Estimated => EstimatedState.Instance,
            RepairStatus.Approved => ApprovedState.Instance,
            RepairStatus.Completed => CompletedState.Instance,
            RepairStatus.Cancelled => CancelledState.Instance,
            _ => throw new ArgumentOutOfRangeException(nameof(status))
        };
        repair.persistedStatus = effectiveStatus;
        return repair;
    }

    public void CreateEstimate(IEnumerable<RepairItem> estimateItems)
    {
        SynchronizeStateWithPersistedStatus();
        var materialisedItems = estimateItems?.ToList() ?? throw new ArgumentNullException(nameof(estimateItems));
        state.CreateEstimate(this, materialisedItems);
    }

    public void Approve(DateOnly date)
    {
        SynchronizeStateWithPersistedStatus();
        state.Approve(this, date);
    }

    public void Complete(DateOnly date)
    {
        SynchronizeStateWithPersistedStatus();
        state.Complete(this, date);
    }

    public void Cancel(DateOnly date)
    {
        SynchronizeStateWithPersistedStatus();
        state.Cancel(this, date);
    }

    private void SynchronizeStateWithPersistedStatus() =>
        state = CreateState(persistedStatus);

    internal void ApplyEstimate(IReadOnlyCollection<RepairItem> estimateItems)
    {
        if (estimateItems.Count == 0) throw new InvalidDomainOperationException("An estimate must contain at least one part.");
        if (estimateItems.GroupBy(item => item.PartId).Any(group => group.Count() > 1))
        {
            throw new InvalidDomainOperationException("An estimate cannot contain duplicate parts.");
        }

        items.Clear();
        items.AddRange(estimateItems);
        Price = items.Select(item => item.Total).Aggregate(Money.Zero, (total, itemTotal) => total + itemTotal);
        state = EstimatedState.Instance;
        persistedStatus = RepairStatus.Estimated;
    }

    internal void ApplyApproval(DateOnly date)
    {
        ApprovedDate = date;
        state = ApprovedState.Instance;
        persistedStatus = RepairStatus.Approved;
    }

    internal void ApplyCompletion(DateOnly date)
    {
        CompletedDate = date;
        state = CompletedState.Instance;
        persistedStatus = RepairStatus.Completed;
    }

    internal void ApplyCancellation(DateOnly date)
    {
        CancelledDate = date;
        state = CancelledState.Instance;
        persistedStatus = RepairStatus.Cancelled;
    }

    private static IRepairState CreateState(RepairStatus status) => status switch
    {
        RepairStatus.Logged => LoggedState.Instance,
        RepairStatus.Estimated => EstimatedState.Instance,
        RepairStatus.Approved => ApprovedState.Instance,
        RepairStatus.Completed => CompletedState.Instance,
        RepairStatus.Cancelled => CancelledState.Instance,
        _ => throw new ArgumentOutOfRangeException(nameof(status))
    };

    private static string ValidateDescription(string value)
    {
        var normalised = value?.Trim() ?? string.Empty;
        if (normalised.Length == 0 || normalised.Length > 200) throw new ArgumentException("A repair description is required.", nameof(value));
        return normalised;
    }

    private static string ValidateCode(string value, string parameterName, int maxLength)
    {
        var normalised = value?.Trim() ?? string.Empty;
        if (normalised.Length == 0 || normalised.Length > maxLength) throw new ArgumentException($"{parameterName} is required.", parameterName);
        return normalised;
    }
}

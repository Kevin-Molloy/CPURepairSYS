using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.Exceptions;

namespace CPURepairSYS.Domain.States;

public abstract class RepairStateBase : IRepairState
{
    public abstract RepairStatus Status { get; }

    public virtual void CreateEstimate(Repair repair, IReadOnlyCollection<RepairItem> items) => Reject("create an estimate");
    public virtual void Approve(Repair repair, DateOnly date) => Reject("approve");
    public virtual void Complete(Repair repair, DateOnly date) => Reject("complete");
    public virtual void Cancel(Repair repair, DateOnly date) => Reject("cancel");

    private void Reject(string operation) => throw new InvalidDomainOperationException($"A repair in the {Status} state cannot {operation}.");
}

public sealed class LoggedState : RepairStateBase
{
    public static LoggedState Instance { get; } = new();
    private LoggedState() { }
    public override RepairStatus Status => RepairStatus.Logged;
    public override void CreateEstimate(Repair repair, IReadOnlyCollection<RepairItem> items) => repair.ApplyEstimate(items);
    public override void Cancel(Repair repair, DateOnly date) => repair.ApplyCancellation(date);
}

public sealed class EstimatedState : RepairStateBase
{
    public static EstimatedState Instance { get; } = new();
    private EstimatedState() { }
    public override RepairStatus Status => RepairStatus.Estimated;
    public override void Approve(Repair repair, DateOnly date) => repair.ApplyApproval(date);
    public override void Cancel(Repair repair, DateOnly date) => repair.ApplyCancellation(date);
}

public sealed class ApprovedState : RepairStateBase
{
    public static ApprovedState Instance { get; } = new();
    private ApprovedState() { }
    public override RepairStatus Status => RepairStatus.Approved;
    public override void Complete(Repair repair, DateOnly date) => repair.ApplyCompletion(date);
    public override void Cancel(Repair repair, DateOnly date) => repair.ApplyCancellation(date);
}

public sealed class CompletedState : RepairStateBase
{
    public static CompletedState Instance { get; } = new();
    private CompletedState() { }
    public override RepairStatus Status => RepairStatus.Completed;
}

public sealed class CancelledState : RepairStateBase
{
    public static CancelledState Instance { get; } = new();
    private CancelledState() { }
    public override RepairStatus Status => RepairStatus.Cancelled;
}

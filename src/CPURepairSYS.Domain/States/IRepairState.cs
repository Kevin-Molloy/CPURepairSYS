using CPURepairSYS.Domain.Entities;

namespace CPURepairSYS.Domain.States;

public interface IRepairState
{
    RepairStatus Status { get; }
    void CreateEstimate(Repair repair, IReadOnlyCollection<RepairItem> items);
    void Approve(Repair repair, DateOnly date);
    void Complete(Repair repair, DateOnly date);
    void Cancel(Repair repair, DateOnly date);
}

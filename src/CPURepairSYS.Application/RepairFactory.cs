using CPURepairSYS.Application.Abstractions;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application;

public sealed class RepairFactory : IRepairFactory
{
    public Repair Create(
        RepairId id,
        string description,
        string repairTypeCode,
        CustomerId customerId,
        DateOnly startDate) =>
        Repair.CreateLogged(id, description, repairTypeCode, customerId, startDate);
}

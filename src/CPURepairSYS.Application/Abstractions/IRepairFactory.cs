using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application.Abstractions;

public interface IRepairFactory
{
    Repair Create(
        RepairId id,
        string description,
        string repairTypeCode,
        CustomerId customerId,
        DateOnly startDate);
}

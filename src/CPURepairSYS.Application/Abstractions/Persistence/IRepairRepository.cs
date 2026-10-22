using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application.Abstractions.Persistence;

public interface IRepairRepository
{
    Task<Repair?> GetByIdAsync(RepairId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Repair>> SearchAsync(string? repairTypeCode, RepairStatus? status, CancellationToken cancellationToken = default);
    Task AddAsync(Repair repair, CancellationToken cancellationToken = default);
    void Update(Repair repair);
}

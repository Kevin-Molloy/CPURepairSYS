using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application.Abstractions.Persistence;

public interface IPartRepository
{
    Task<PartId> GetNextIdAsync(CancellationToken cancellationToken = default);
    Task<Part?> GetByIdAsync(PartId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Part>> SearchAsync(string? description, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Part>> SearchForEstimateAsync(string? description, string? partTypeCode, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Part>> SearchAvailableAsync(string? description, CancellationToken cancellationToken = default);
    Task AddAsync(Part part, CancellationToken cancellationToken = default);
    void Update(Part part);
}

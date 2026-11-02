using CPURepairSYS.Domain.Entities;

namespace CPURepairSYS.Application.Abstractions.Persistence;

public interface IRepairReportSource
{
    Task<IReadOnlyList<Repair>> GetRepairsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Part>> GetPartsAsync(CancellationToken cancellationToken = default);
}

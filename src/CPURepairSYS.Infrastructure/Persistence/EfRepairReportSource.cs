using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Domain.Entities;

namespace CPURepairSYS.Infrastructure.Persistence;

internal sealed class EfRepairReportSource(
    IRepairRepository repairs,
    IPartRepository parts) : IRepairReportSource
{
    public Task<IReadOnlyList<Repair>> GetRepairsAsync(CancellationToken cancellationToken = default) =>
        repairs.SearchAsync(null, null, cancellationToken);

    public Task<IReadOnlyList<Part>> GetPartsAsync(CancellationToken cancellationToken = default) =>
        parts.SearchAsync(null, cancellationToken);
}

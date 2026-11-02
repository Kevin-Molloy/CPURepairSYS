using CPURepairSYS.Application.Abstractions;
using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Application.Common;
using CPURepairSYS.Application.Dtos;
using CPURepairSYS.Application.Strategies;
using CPURepairSYS.Domain.Entities;

namespace CPURepairSYS.Application.Facades;

public sealed class ReportingFacade(
    IRepairReportSource source,
    IApplicationAuthorizer authorizer,
    IRepairReportStrategy repairStrategy,
    IPartReportStrategy partStrategy)
{
    public async Task<ApplicationResult<IReadOnlyList<RepairReportRow>>> GetRepairHistoryAsync(int year, RepairStatus? status, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Report, cancellationToken);
        if (year is < 1 or > 9999) return ApplicationResult<IReadOnlyList<RepairReportRow>>.Failure(new ValidationError(nameof(year), "Year is invalid."));
        var repairs = await source.GetRepairsAsync(cancellationToken);
        return ApplicationResult<IReadOnlyList<RepairReportRow>>.Success(repairStrategy.Apply(repairs, year, status).ToList());
    }

    public async Task<ApplicationResult<IReadOnlyList<PartReportRow>>> GetPartsReportAsync(CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Report, cancellationToken);
        var parts = await source.GetPartsAsync(cancellationToken);
        var repairs = await source.GetRepairsAsync(cancellationToken);
        return ApplicationResult<IReadOnlyList<PartReportRow>>.Success(partStrategy.Apply(parts, repairs).ToList());
    }

    public async Task<ApplicationResult<IReadOnlyList<RevenueReportRow>>> GetRevenueAsync(int year, bool includeCancelled, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Report, cancellationToken);
        if (year is < 1 or > 9999) return ApplicationResult<IReadOnlyList<RevenueReportRow>>.Failure(new ValidationError(nameof(year), "Year is invalid."));
        var repairs = await source.GetRepairsAsync(cancellationToken);
        var result = repairs.Where(repair => repair.CompletedDate?.Year == year && (includeCancelled || repair.Status != RepairStatus.Cancelled))
            .OrderBy(repair => repair.CompletedDate)
            .Select(repair => new RevenueReportRow(new RepairSummary(repair.Id, repair.Description, repair.RepairTypeCode, repair.CustomerId, repair.Status, repair.Price, repair.StartDate)))
            .ToList();
        return ApplicationResult<IReadOnlyList<RevenueReportRow>>.Success(result);
    }
}

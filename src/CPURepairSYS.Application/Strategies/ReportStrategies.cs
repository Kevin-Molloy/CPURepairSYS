using CPURepairSYS.Application.Dtos;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application.Strategies;

public interface IRepairReportStrategy
{
    IEnumerable<RepairReportRow> Apply(IEnumerable<Repair> repairs, int year, RepairStatus? status);
}

public sealed class RepairsByYearStrategy : IRepairReportStrategy
{
    public IEnumerable<RepairReportRow> Apply(IEnumerable<Repair> repairs, int year, RepairStatus? status) =>
        repairs.Where(repair => repair.StartDate?.Year == year && (!status.HasValue || repair.EffectiveStatus == status.Value))
            .OrderBy(repair => repair.StartDate)
            .Select(repair => new RepairReportRow(ToSummary(repair), year));

    private static RepairSummary ToSummary(Repair repair) =>
        new(repair.Id, repair.Description, repair.RepairTypeCode, repair.CustomerId, repair.EffectiveStatus, repair.Price ?? Money.Zero, repair.StartDate);
}

public sealed class RepairsByStatusStrategy : IRepairReportStrategy
{
    public IEnumerable<RepairReportRow> Apply(IEnumerable<Repair> repairs, int year, RepairStatus? status) =>
        repairs.Where(repair => repair.StartDate?.Year == year && status.HasValue && repair.EffectiveStatus == status.Value)
            .OrderBy(repair => repair.Description)
            .Select(repair => new RepairReportRow(
                new RepairSummary(repair.Id, repair.Description, repair.RepairTypeCode, repair.CustomerId, repair.EffectiveStatus, repair.Price ?? Money.Zero, repair.StartDate),
                year));
}

public interface IPartReportStrategy
{
    IEnumerable<PartReportRow> Apply(IEnumerable<Part> parts, IEnumerable<Repair> repairs, int year);
}

public sealed class AvailablePartsStrategy : IPartReportStrategy
{
    public IEnumerable<PartReportRow> Apply(IEnumerable<Part> parts, IEnumerable<Repair> repairs, int year) =>
        parts.Select(part => ToRow(part, repairs, year))
            .Where(row => row.QuantityUsed > 0)
            .OrderBy(row => row.Part.Description);

    private static PartReportRow ToRow(Part part, IEnumerable<Repair> repairs, int year) =>
        new(new PartSummary(part.Id, part.Description, part.Price, part.Quantity, part.Status, part.PartTypeCode),
            repairs.Where(repair => repair.StartDate?.Year == year)
                .SelectMany(repair => repair.Items)
                .Where(item => item.PartId == part.Id)
                .Sum(item => item.Quantity));
}

public sealed class OutOfStockPartsStrategy : IPartReportStrategy
{
    public IEnumerable<PartReportRow> Apply(IEnumerable<Part> parts, IEnumerable<Repair> repairs, int year) =>
        parts.Where(part => part.Status == PartStatus.OutOfStock).OrderBy(part => part.Description).Select(part =>
            new PartReportRow(new PartSummary(part.Id, part.Description, part.Price, part.Quantity, part.Status, part.PartTypeCode), 0));
}

public sealed class DiscontinuedPartsStrategy : IPartReportStrategy
{
    public IEnumerable<PartReportRow> Apply(IEnumerable<Part> parts, IEnumerable<Repair> repairs, int year) =>
        parts.Where(part => part.Status == PartStatus.Discontinued).OrderBy(part => part.Description).Select(part =>
            new PartReportRow(new PartSummary(part.Id, part.Description, part.Price, part.Quantity, part.Status, part.PartTypeCode), 0));
}

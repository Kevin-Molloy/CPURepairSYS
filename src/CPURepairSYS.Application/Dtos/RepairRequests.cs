using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application.Dtos;

public sealed record RegisterCustomerRequest(string FirstName, string Surname, PhoneNumber Phone, string Email, CustomerId Id);
public sealed record LogRepairRequest(RepairId Id, string Description, string RepairTypeCode, CustomerId CustomerId, DateOnly StartDate);
public sealed record EstimateLineRequest(PartId PartId, int Quantity);
public sealed record AddPartRequest(PartId Id, string Description, Money Price, int Quantity, string PartTypeCode);
public sealed record UpdatePartRequest(string Description, Money Price, int Quantity, string PartTypeCode);
public sealed record PartSummary(PartId Id, string Description, Money Price, int Quantity, PartStatus Status, string PartTypeCode);
public sealed record CustomerSummary(CustomerId Id, string FirstName, string Surname, PhoneNumber Phone, string Email);
public sealed record RepairSummary(RepairId Id, string Description, string RepairTypeCode, CustomerId CustomerId, RepairStatus Status, Money Price, DateOnly StartDate);
public sealed record RepairReportRow(RepairSummary Repair, int Year);
public sealed record PartReportRow(PartSummary Part, int QuantityUsed);
public sealed record RevenueReportRow(RepairSummary Repair);

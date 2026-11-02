using CPURepairSYS.Application.Abstractions;
using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Application.Common;
using CPURepairSYS.Application.Dtos;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.Exceptions;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application.Facades;

public sealed class InventoryFacade(IPartRepository parts, IApplicationAuthorizer authorizer)
{
    public async Task<ApplicationResult<IReadOnlyList<PartSummary>>> SearchPartsAsync(string? description, bool availableOnly, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Search, cancellationToken);
        var result = availableOnly
            ? await parts.SearchAvailableAsync(description, cancellationToken)
            : await parts.SearchAsync(description, cancellationToken);
        return ApplicationResult<IReadOnlyList<PartSummary>>.Success(result.Select(ToSummary).ToList());
    }

    public async Task<ApplicationResult<PartSummary>> AddPartAsync(AddPartRequest request, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Create, cancellationToken);
        try
        {
            var part = Part.Create(request.Id, request.Description, request.Price, request.Quantity, request.PartTypeCode);
            await parts.AddAsync(part, cancellationToken);
            return ApplicationResult<PartSummary>.Success(ToSummary(part));
        }
        catch (ArgumentException exception)
        {
            return ApplicationResult<PartSummary>.Failure(new ValidationError(nameof(request), exception.Message));
        }
    }

    public async Task<ApplicationResult<PartSummary>> UpdatePartAsync(PartId id, UpdatePartRequest request, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Update, cancellationToken);
        var part = await parts.GetByIdAsync(id, cancellationToken);
        if (part is null) return ApplicationResult<PartSummary>.Failure(new ValidationError(nameof(id), "Part does not exist."));
        try
        {
            part.UpdateDetails(request.Description, request.Price, request.Quantity, request.PartTypeCode);
            parts.Update(part);
            return ApplicationResult<PartSummary>.Success(ToSummary(part));
        }
        catch (ArgumentException exception)
        {
            return ApplicationResult<PartSummary>.Failure(new ValidationError(nameof(request), exception.Message));
        }
        catch (InvalidDomainOperationException exception)
        {
            return ApplicationResult<PartSummary>.Failure(new ValidationError(nameof(request), exception.Message));
        }
    }

    public async Task<ApplicationResult<PartSummary>> DiscontinuePartAsync(PartId id, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Update, cancellationToken);
        var part = await parts.GetByIdAsync(id, cancellationToken);
        if (part is null) return ApplicationResult<PartSummary>.Failure(new ValidationError(nameof(id), "Part does not exist."));
        part.Discontinue();
        parts.Update(part);
        return ApplicationResult<PartSummary>.Success(ToSummary(part));
    }

    private static PartSummary ToSummary(Part part) => new(part.Id, part.Description, part.Price, part.Quantity, part.Status, part.PartTypeCode);
}

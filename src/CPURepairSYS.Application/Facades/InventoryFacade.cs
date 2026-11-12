using CPURepairSYS.Application.Abstractions;
using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Application.Common;
using CPURepairSYS.Application.Dtos;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.Exceptions;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application.Facades;

public sealed class InventoryFacade(IPartRepository parts, IUnitOfWork unitOfWork, IApplicationAuthorizer authorizer)
{
    public Task<PartId> GetNextPartIdAsync(CancellationToken cancellationToken = default) =>
        parts.GetNextIdAsync(cancellationToken);

    public async Task<ApplicationResult<IReadOnlyList<PartSummary>>> SearchPartsAsync(string? description, bool availableOnly, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Search, cancellationToken);
        var result = availableOnly
            ? await parts.SearchAvailableAsync(description, cancellationToken)
            : await parts.SearchAsync(description, cancellationToken);
        return ApplicationResult<IReadOnlyList<PartSummary>>.Success(result.Select(ToSummary).ToList());
    }

    public async Task<ApplicationResult<IReadOnlyList<PartSummary>>> SearchPartsForEstimateAsync(string? description, string? partTypeCode, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Search, cancellationToken);
        var result = await parts.SearchForEstimateAsync(description, partTypeCode, cancellationToken);
        return ApplicationResult<IReadOnlyList<PartSummary>>.Success(result.Select(ToSummary).ToList());
    }

    public async Task<ApplicationResult<PartSummary>> AddPartAsync(AddPartRequest request, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Create, cancellationToken);
        try
        {
            var part = Part.Create(
                await parts.GetNextIdAsync(cancellationToken),
                request.Description,
                request.Price,
                request.Quantity,
                request.PartTypeCode);
            await parts.AddAsync(part, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
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
            await unitOfWork.SaveChangesAsync(cancellationToken);
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
        try
        {
            part.Discontinue();
            parts.Update(part);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return ApplicationResult<PartSummary>.Success(ToSummary(part));
        }
        catch (InvalidDomainOperationException exception)
        {
            return ApplicationResult<PartSummary>.Failure(new ValidationError(nameof(id), exception.Message));
        }
    }

    public async Task<ApplicationResult<PartSummary>> ReinstatePartAsync(PartId id, int quantity, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Update, cancellationToken);
        var part = await parts.GetByIdAsync(id, cancellationToken);
        if (part is null) return ApplicationResult<PartSummary>.Failure(new ValidationError(nameof(id), "Part does not exist."));
        try
        {
            part.Reinstate(quantity);
            parts.Update(part);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return ApplicationResult<PartSummary>.Success(ToSummary(part));
        }
        catch (ArgumentOutOfRangeException exception)
        {
            return ApplicationResult<PartSummary>.Failure(new ValidationError(nameof(quantity), exception.Message));
        }
        catch (InvalidDomainOperationException exception)
        {
            return ApplicationResult<PartSummary>.Failure(new ValidationError(nameof(id), exception.Message));
        }
    }

    private static PartSummary ToSummary(Part part) => new(part.Id, part.Description, part.Price, part.Quantity, part.Status, part.PartTypeCode);
}

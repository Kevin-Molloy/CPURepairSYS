using CPURepairSYS.Application.Abstractions;
using CPURepairSYS.Application.Abstractions.Persistence;
using CPURepairSYS.Application.Common;
using CPURepairSYS.Application.Dtos;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.Exceptions;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application.Facades;

public sealed class RepairFacade(
    ICustomerRepository customers,
    IRepairRepository repairs,
    IPartRepository parts,
    IRepairDataAdapter transaction,
    IUnitOfWork unitOfWork,
    IRepairFactory factory,
    IApplicationAuthorizer authorizer)
{
    public Task<CustomerId> GetNextCustomerIdAsync(CancellationToken cancellationToken = default) =>
        customers.GetNextIdAsync(cancellationToken);

    public Task<RepairId> GetNextRepairIdAsync(CancellationToken cancellationToken = default) =>
        repairs.GetNextIdAsync(cancellationToken);

    public async Task<ApplicationResult<IReadOnlyList<CustomerSummary>>> SearchCustomersAsync(string? phone, string? firstName, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Search, cancellationToken);
        var result = await customers.SearchAsync(phone, firstName, cancellationToken);
        return ApplicationResult<IReadOnlyList<CustomerSummary>>.Success(result.Select(ToSummary).ToList());
    }

    public async Task<ApplicationResult<CustomerSummary>> RegisterCustomerAsync(RegisterCustomerRequest request, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Create, cancellationToken);
        if (await customers.PhoneExistsAsync(request.Phone, cancellationToken: cancellationToken))
            return ApplicationResult<CustomerSummary>.Failure(new ValidationError(nameof(request.Phone), "Phone number is already registered."));
        if (await customers.EmailExistsAsync(request.Email, cancellationToken: cancellationToken))
            return ApplicationResult<CustomerSummary>.Failure(new ValidationError(nameof(request.Email), "Email is already registered."));
        try
        {
            var customer = Customer.Create(
                await customers.GetNextIdAsync(cancellationToken),
                request.FirstName,
                request.Surname,
                request.Phone,
                request.Email);
            await customers.AddAsync(customer, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return ApplicationResult<CustomerSummary>.Success(ToSummary(customer));
        }
        catch (ArgumentException exception)
        {
            return ApplicationResult<CustomerSummary>.Failure(new ValidationError(nameof(request), exception.Message));
        }
    }

    public async Task<ApplicationResult<CustomerSummary>> UpdateCustomerAsync(CustomerId id, UpdateCustomerRequest request, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Update, cancellationToken);
        var customer = await customers.GetByIdAsync(id, cancellationToken);
        if (customer is null)
        {
            return ApplicationResult<CustomerSummary>.Failure(new ValidationError(nameof(id), "Customer does not exist."));
        }

        try
        {
            if (await customers.PhoneExistsAsync(request.Phone, id, cancellationToken))
                return ApplicationResult<CustomerSummary>.Failure(new ValidationError(nameof(request.Phone), "Phone number is already registered."));
            if (await customers.EmailExistsAsync(request.Email, id, cancellationToken))
                return ApplicationResult<CustomerSummary>.Failure(new ValidationError(nameof(request.Email), "Email is already registered."));
            customer.UpdateDetails(request.FirstName, request.Surname, request.Phone, request.Email);
            customers.Update(customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return ApplicationResult<CustomerSummary>.Success(ToSummary(customer));
        }
        catch (ArgumentException exception)
        {
            return ApplicationResult<CustomerSummary>.Failure(new ValidationError(nameof(request), exception.Message));
        }
    }

    public async Task<ApplicationResult<RepairSummary>> LogRepairAsync(LogRepairRequest request, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Create, cancellationToken);
        if (await customers.GetByIdAsync(request.CustomerId, cancellationToken) is null)
        {
            return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(request.CustomerId), "Customer does not exist."));
        }

        try
        {
            var repair = factory.Create(
                await repairs.GetNextIdAsync(cancellationToken),
                request.Description,
                request.RepairTypeCode,
                request.CustomerId,
                request.StartDate);
            await repairs.AddAsync(repair, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return ApplicationResult<RepairSummary>.Success(ToSummary(repair));
        }
        catch (ArgumentException exception)
        {
            return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(request), exception.Message));
        }
    }

    public async Task<ApplicationResult<IReadOnlyList<RepairSummary>>> SearchRepairsAsync(string? repairTypeCode, RepairStatus? status, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Search, cancellationToken);
        var result = await repairs.SearchAsync(repairTypeCode, status, cancellationToken);
        return ApplicationResult<IReadOnlyList<RepairSummary>>.Success(result.Select(ToSummary).ToList());
    }

    public async Task<ApplicationResult<RepairSummary>> ApproveRepairAsync(RepairId id, DateOnly date, CancellationToken cancellationToken = default) =>
        await TransitionAsync(id, date, ApplicationOperation.Approve, (repair, value) => repair.Approve(value), cancellationToken);

    public async Task<ApplicationResult<RepairSummary>> CancelRepairAsync(RepairId id, DateOnly date, CancellationToken cancellationToken = default) =>
        await TransitionAsync(id, date, ApplicationOperation.Cancel, (repair, value) => repair.Cancel(value), cancellationToken);

    public async Task<ApplicationResult<RepairSummary>> CompleteRepairAsync(RepairId id, DateOnly date, CancellationToken cancellationToken = default) =>
        await TransitionAsync(id, date, ApplicationOperation.Complete, (repair, value) => repair.Complete(value), cancellationToken);

    public async Task<ApplicationResult<RepairSummary>> GetRepairAsync(RepairId id, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Search, cancellationToken);
        var repair = await repairs.GetByIdAsync(id, cancellationToken);
        if (repair is null)
        {
            return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(id), "Repair does not exist."));
        }

        var customer = await customers.GetByIdAsync(repair.CustomerId, cancellationToken);
        return ApplicationResult<RepairSummary>.Success(ToSummary(repair, customer));
    }

    public async Task<ApplicationResult<RepairSummary>> CreateEstimateAsync(RepairId id, IReadOnlyCollection<EstimateLineRequest> lines, CancellationToken cancellationToken = default)
    {
        await authorizer.AuthorizeAsync(ApplicationOperation.Update, cancellationToken);
        return await transaction.ExecuteInTransactionAsync(async token =>
        {
            var repair = await repairs.GetByIdAsync(id, token);
            if (repair is null) return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(id), "Repair does not exist."));
            if (lines.Count == 0) return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(lines), "An estimate must contain at least one part."));
            if (lines.Any(line => line.Quantity <= 0)) return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(lines), "Estimate quantities must be positive."));

            try
            {
                var items = new List<RepairItem>();
                foreach (var group in lines.GroupBy(line => line.PartId))
                {
                    var quantity = group.Sum(line => line.Quantity);
                    var part = await parts.GetByIdAsync(group.Key, token);
                    if (part is null) return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(group.Key), "Part does not exist."));
                    if (part.Status != PartStatus.Available || quantity > part.Quantity)
                    {
                        return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(group.Key), "Part does not have sufficient available stock."));
                    }
                    part.Allocate(quantity);
                    parts.Update(part);
                    items.Add(RepairItem.Create(part.Id, part.Price, quantity));
                }

                repair.CreateEstimate(items);
                repairs.Update(repair);
                return ApplicationResult<RepairSummary>.Success(ToSummary(repair));
            }
            catch (ArgumentException exception)
            {
                return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(lines), exception.Message));
            }
            catch (InvalidDomainOperationException exception)
            {
                return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(lines), exception.Message));
            }
        }, cancellationToken);
    }

    private async Task<ApplicationResult<RepairSummary>> TransitionAsync(
        RepairId id,
        DateOnly date,
        ApplicationOperation operation,
        Action<Repair, DateOnly> transition,
        CancellationToken cancellationToken)
    {
        await authorizer.AuthorizeAsync(operation, cancellationToken);
        return await transaction.ExecuteInTransactionAsync(async token =>
        {
            var repair = await repairs.GetByIdAsync(id, token);
            if (repair is null) return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(id), "Repair does not exist."));
            try
            {
                transition(repair, date);
                repairs.Update(repair);
                var customer = await customers.GetByIdAsync(repair.CustomerId, token);
                return ApplicationResult<RepairSummary>.Success(ToSummary(repair, customer));
            }
            catch (InvalidDomainOperationException exception)
            {
                return ApplicationResult<RepairSummary>.Failure(new ValidationError(nameof(id), exception.Message));
            }
        }, cancellationToken);
    }

    private static CustomerSummary ToSummary(Customer customer) => new(customer.Id, customer.FirstName, customer.Surname, customer.Phone, customer.Email);
    private static RepairSummary ToSummary(Repair repair) => new(repair.Id, repair.Description, repair.RepairTypeCode, repair.CustomerId, repair.Status, repair.Price ?? Money.Zero, repair.StartDate);
    private static RepairSummary ToSummary(Repair repair, Customer? customer) =>
        new(repair.Id, repair.Description, repair.RepairTypeCode, repair.CustomerId, repair.Status,
            repair.Price ?? Money.Zero, repair.StartDate,
            customer is null ? string.Empty : $"{customer.FirstName} {customer.Surname}".Trim());
}

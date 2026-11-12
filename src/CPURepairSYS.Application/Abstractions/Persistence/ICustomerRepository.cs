using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Application.Abstractions.Persistence;

public interface ICustomerRepository
{
    Task<CustomerId> GetNextIdAsync(CancellationToken cancellationToken = default);
    Task<Customer?> GetByIdAsync(CustomerId id, CancellationToken cancellationToken = default);
    Task<bool> EmailExistsAsync(string email, CustomerId? excludingId = null, CancellationToken cancellationToken = default);
    Task<bool> PhoneExistsAsync(PhoneNumber phone, CustomerId? excludingId = null, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Customer>> SearchAsync(string? phone, string? firstName, CancellationToken cancellationToken = default);
    Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
    void Update(Customer customer);
}

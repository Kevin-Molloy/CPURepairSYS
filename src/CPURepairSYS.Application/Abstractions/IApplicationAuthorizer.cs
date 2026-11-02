namespace CPURepairSYS.Application.Abstractions;

public enum ApplicationOperation
{
    Search,
    Create,
    Update,
    Approve,
    Cancel,
    Complete,
    Report
}

public interface IApplicationAuthorizer
{
    Task AuthorizeAsync(ApplicationOperation operation, CancellationToken cancellationToken = default);
}

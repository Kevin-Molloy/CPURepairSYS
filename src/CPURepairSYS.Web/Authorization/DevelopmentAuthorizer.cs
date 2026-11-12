using CPURepairSYS.Application.Abstractions;

namespace CPURepairSYS.Web.Authorization;

public sealed class DevelopmentAuthorizer : IApplicationAuthorizer
{
    public Task AuthorizeAsync(ApplicationOperation operation, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}

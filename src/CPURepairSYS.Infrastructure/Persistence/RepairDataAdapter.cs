using CPURepairSYS.Application.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CPURepairSYS.Infrastructure.Persistence;

internal sealed class RepairDataAdapter(RepairDbContext db) : IRepairDataAdapter
{
    public async Task<T> ExecuteInTransactionAsync<T>(
        Func<CancellationToken, Task<T>> operation,
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);
        var result = await operation(cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return result;
    }
}

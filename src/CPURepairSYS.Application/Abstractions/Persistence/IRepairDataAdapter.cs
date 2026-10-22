namespace CPURepairSYS.Application.Abstractions.Persistence;

public interface IRepairDataAdapter
{
    Task<T> ExecuteInTransactionAsync<T>(
        Func<CancellationToken, Task<T>> operation,
        CancellationToken cancellationToken = default);
}

namespace CPURepairSYS.Application.Common;

public sealed record ValidationError(string Field, string Message);

public sealed class ApplicationResult
{
    private ApplicationResult(bool succeeded, IReadOnlyList<ValidationError> errors)
    {
        Succeeded = succeeded;
        Errors = errors;
    }

    public bool Succeeded { get; }
    public IReadOnlyList<ValidationError> Errors { get; }

    public static ApplicationResult Success() => new(true, Array.Empty<ValidationError>());
    public static ApplicationResult Failure(params ValidationError[] errors) => new(false, errors);
}

public sealed class ApplicationResult<T>
{
    private ApplicationResult(T? value, bool succeeded, IReadOnlyList<ValidationError> errors)
    {
        Value = value;
        Succeeded = succeeded;
        Errors = errors;
    }

    public T? Value { get; }
    public bool Succeeded { get; }
    public IReadOnlyList<ValidationError> Errors { get; }

    public static ApplicationResult<T> Success(T value) =>
        new(value, true, Array.Empty<ValidationError>());

    public static ApplicationResult<T> Failure(params ValidationError[] errors) =>
        new(default, false, errors);
}

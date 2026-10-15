namespace CPURepairSYS.Domain.Exceptions;

public sealed class InvalidDomainOperationException : InvalidOperationException
{
    public InvalidDomainOperationException(string message) : base(message)
    {
    }
}

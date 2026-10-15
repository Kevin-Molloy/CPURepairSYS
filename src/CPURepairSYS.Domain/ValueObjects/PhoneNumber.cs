namespace CPURepairSYS.Domain.ValueObjects;

public readonly record struct PhoneNumber
{
    public PhoneNumber(string value)
    {
        var normalised = value?.Trim() ?? string.Empty;
        if (normalised.Length is < 1 or > 10 || normalised.Any(character => !char.IsDigit(character)))
        {
            throw new ArgumentException("Phone number must contain between 1 and 10 digits.", nameof(value));
        }

        Value = normalised;
    }

    public string Value { get; }

    public override string ToString() => Value;
}

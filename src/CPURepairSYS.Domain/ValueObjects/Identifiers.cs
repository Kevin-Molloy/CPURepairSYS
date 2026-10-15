namespace CPURepairSYS.Domain.ValueObjects;

public readonly record struct CustomerId
{
    public CustomerId(int value)
    {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }

    public int Value { get; }
}

public readonly record struct PartId
{
    public PartId(int value)
    {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }

    public int Value { get; }
}

public readonly record struct RepairId
{
    public RepairId(int value)
    {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }

    public int Value { get; }
}

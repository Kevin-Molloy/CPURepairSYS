using CPURepairSYS.Domain.Exceptions;
using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Domain.Entities;

public enum PartStatus
{
    Available,
    OutOfStock,
    Discontinued
}

public sealed class Part
{
    private Part(PartId id, string description, Money price, int quantity, string partTypeCode)
    {
        Id = id;
        Description = ValidateDescription(description);
        Price = price;
        Quantity = ValidateQuantity(quantity);
        PartTypeCode = ValidateCode(partTypeCode, nameof(partTypeCode), 8);
        Status = quantity == 0 ? PartStatus.OutOfStock : PartStatus.Available;
    }

    public PartId Id { get; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public int Quantity { get; private set; }
    public PartStatus Status { get; private set; }
    public string PartTypeCode { get; private set; }

    public static Part Create(PartId id, string description, Money price, int quantity, string partTypeCode) =>
        new(id, description, price, quantity, partTypeCode);

    public void Allocate(int quantity)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (Status != PartStatus.Available) throw new InvalidDomainOperationException("Only available parts can be allocated.");
        if (quantity > Quantity) throw new InvalidDomainOperationException("Requested quantity exceeds available stock.");

        Quantity -= quantity;
        if (Quantity == 0) Status = PartStatus.OutOfStock;
    }

    public void Restock(int quantity)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (Status == PartStatus.Discontinued) throw new InvalidDomainOperationException("Discontinued parts cannot be restocked.");

        Quantity += quantity;
        Status = PartStatus.Available;
    }

    public void Discontinue()
    {
        Status = PartStatus.Discontinued;
        Quantity = 0;
    }

    private static int ValidateQuantity(int quantity)
    {
        if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        return quantity;
    }

    private static string ValidateDescription(string value)
    {
        var normalised = value?.Trim() ?? string.Empty;
        if (normalised.Length == 0 || normalised.Length > 50) throw new ArgumentException("A part description is required.", nameof(value));
        return normalised;
    }

    private static string ValidateCode(string value, string parameterName, int maxLength)
    {
        var normalised = value?.Trim() ?? string.Empty;
        if (normalised.Length == 0 || normalised.Length > maxLength) throw new ArgumentException($"{parameterName} is required.", parameterName);
        return normalised;
    }
}

using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Domain.Entities;

public sealed class RepairItem
{
    private RepairItem(PartId partId, Money unitPrice, int quantity)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        PartId = partId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public PartId PartId { get; }
    public Money UnitPrice { get; }
    public int Quantity { get; }
    public Money Total => UnitPrice * Quantity;

    public static RepairItem Create(PartId partId, Money unitPrice, int quantity) => new(partId, unitPrice, quantity);
}

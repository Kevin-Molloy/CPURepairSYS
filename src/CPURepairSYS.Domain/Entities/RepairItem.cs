using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Domain.Entities;

public sealed class RepairItem
{
    private RepairItem()
    {
    }

    private RepairItem(PartId partId, Money unitPrice, int quantity)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        PartId = partId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public PartId PartId { get; private set; }
    public Money UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public Money Total => UnitPrice * Quantity;

    public static RepairItem Create(PartId partId, Money unitPrice, int quantity) => new(partId, unitPrice, quantity);
}

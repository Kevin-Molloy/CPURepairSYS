using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPURepairSYS.Infrastructure.Persistence;

internal static class PersistenceConversions
{
    public static string PartStatusToCode(PartStatus status) => status switch
    {
        PartStatus.Available => "A",
        PartStatus.OutOfStock => "O",
        PartStatus.Discontinued => "D",
        _ => throw new ArgumentOutOfRangeException(nameof(status))
    };

    public static PartStatus CodeToPartStatus(string code) => code switch
    {
        "A" => PartStatus.Available,
        "O" => PartStatus.OutOfStock,
        "D" => PartStatus.Discontinued,
        _ => throw new InvalidOperationException($"Unknown part status '{code}'.")
    };

    public static string RepairStatusToCode(RepairStatus status) => status switch
    {
        RepairStatus.Logged => "L",
        RepairStatus.Estimated => "E",
        RepairStatus.Approved => "A",
        RepairStatus.Completed => "C",
        RepairStatus.Cancelled => "X",
        _ => throw new ArgumentOutOfRangeException(nameof(status))
    };

    public static RepairStatus CodeToRepairStatus(string code) => code switch
    {
        "L" => RepairStatus.Logged,
        "E" => RepairStatus.Estimated,
        "A" => RepairStatus.Approved,
        "C" => RepairStatus.Completed,
        "X" => RepairStatus.Cancelled,
        _ => throw new InvalidOperationException($"Unknown repair status '{code}'.")
    };
}

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("CustId").ValueGeneratedOnAdd().HasDefaultValueSql("SEQ_CUSTOMERS.NEXTVAL")
            .HasConversion(x => x.Value, x => new CustomerId(x));
        builder.Property(x => x.FirstName).HasColumnName("FName").HasMaxLength(15).IsRequired();
        builder.Property(x => x.Surname).HasColumnName("SName").HasMaxLength(15).IsRequired();
        builder.Property(x => x.Phone).HasColumnName("Phone").HasMaxLength(10).IsRequired()
            .HasConversion(x => x.Value, x => new PhoneNumber(x));
        builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(25).IsRequired();
        builder.HasIndex(x => x.Phone).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
    }
}

internal sealed class PartConfiguration : IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> builder)
    {
        builder.ToTable("Parts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("PartId").ValueGeneratedOnAdd().HasDefaultValueSql("SEQ_PARTS.NEXTVAL")
            .HasConversion(x => x.Value, x => new PartId(x));
        builder.Property(x => x.Description).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Price).HasColumnName("Price").HasPrecision(5, 2)
            .HasConversion(x => x.Amount, x => new Money(x));
        builder.Property(x => x.Quantity).HasColumnName("Quantity").IsRequired();
        builder.Property(x => x.Status).HasColumnName("Status").HasMaxLength(1)
            .HasConversion(new ValueConverter<PartStatus, string>(x => PersistenceConversions.PartStatusToCode(x), x => PersistenceConversions.CodeToPartStatus(x)));
        builder.Property(x => x.PartTypeCode).HasMaxLength(8).IsRequired();
        builder.HasIndex(x => x.Description).IsUnique();
    }
}

internal sealed class RepairConfiguration : IEntityTypeConfiguration<Repair>
{
    public void Configure(EntityTypeBuilder<Repair> builder)
    {
        builder.ToTable("Repairs");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("RepairId").ValueGeneratedOnAdd().HasDefaultValueSql("SEQ_REPAIRS.NEXTVAL")
            .HasConversion(x => x.Value, x => new RepairId(x));
        builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
        builder.Property<RepairStatus>("PersistedStatus").HasColumnName("Status").HasMaxLength(2)
            .HasConversion(new ValueConverter<RepairStatus, string>(x => PersistenceConversions.RepairStatusToCode(x), x => PersistenceConversions.CodeToRepairStatus(x)));
        builder.Property(x => x.Price).HasPrecision(6, 2).HasConversion(x => x.Amount, x => new Money(x));
        builder.Property(x => x.StartDate).HasColumnName("StartDate").HasConversion(x => x.ToDateTime(TimeOnly.MinValue), x => DateOnly.FromDateTime(x));
        builder.Property(x => x.CompletedDate).HasColumnName("CompleteDate")
            .HasConversion(new ValueConverter<DateOnly?, DateTime?>(
                x => x.HasValue ? x.Value.ToDateTime(TimeOnly.MinValue) : null,
                x => x.HasValue ? DateOnly.FromDateTime(x.Value) : null));
        builder.Ignore(x => x.ApprovedDate);
        builder.Ignore(x => x.CancelledDate);
        builder.Property(x => x.RepairTypeCode).HasMaxLength(8).IsRequired();
        builder.Property(x => x.CustomerId).HasColumnName("CustId")
            .HasConversion(x => x.Value, x => new CustomerId(x));
        builder.HasMany(x => x.Items).WithOne().HasForeignKey("RepairId");
        builder.HasIndex(x => x.Description).IsUnique();
        builder.Navigation(x => x.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

internal sealed class RepairItemConfiguration : IEntityTypeConfiguration<RepairItem>
{
    public void Configure(EntityTypeBuilder<RepairItem> builder)
    {
        builder.ToTable("RepairItems");
        builder.HasKey("RepairId", nameof(RepairItem.PartId));
        builder.Property<RepairId>("RepairId").HasColumnName("RepairId")
            .HasConversion(x => x.Value, x => new RepairId(x));
        builder.Property(x => x.PartId).HasColumnName("PartId")
            .HasConversion(x => x.Value, x => new PartId(x));
        builder.Property(x => x.UnitPrice).HasColumnName("Price").HasPrecision(6, 2)
            .HasConversion(x => x.Amount, x => new Money(x));
        builder.Property(x => x.Quantity).HasColumnName("QuantityUsed");
        builder.Property<string>("Status").HasColumnName("Status").HasMaxLength(1).HasDefaultValue("U");
    }

}

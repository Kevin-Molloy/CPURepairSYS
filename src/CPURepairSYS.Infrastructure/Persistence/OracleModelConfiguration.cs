using System.Globalization;
using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPURepairSYS.Infrastructure.Persistence;

internal static class PersistenceConversions
{
    public static string? DateOnlyToOracleString(DateOnly? value) =>
        value?.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);

    public static DateOnly? OracleStringToDateOnly(string? value) =>
        string.IsNullOrWhiteSpace(value)
            ? null
            : DateOnly.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out var result)
                ? result
                : throw new InvalidOperationException($"Invalid Oracle repair date '{value}'.");

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
        builder.ToTable("CUSTOMERS");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("CUSTID").ValueGeneratedOnAdd().HasDefaultValueSql("SEQ_CUSTOMERS.NEXTVAL")
            .HasConversion(x => x.Value, x => new CustomerId(x));
        builder.Property(x => x.FirstName).HasColumnName("FNAME").HasMaxLength(15).IsRequired();
        builder.Property(x => x.Surname).HasColumnName("SNAME").HasMaxLength(15).IsRequired();
        builder.Property(x => x.Phone).HasColumnName("PHONE").HasMaxLength(10).IsRequired()
            .HasConversion(x => x.Value, x => new PhoneNumber(x));
        builder.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(25).IsRequired();
        builder.HasIndex(x => x.Phone).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
    }
}

internal sealed class PartConfiguration : IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> builder)
    {
        builder.ToTable("PARTS");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("PARTID").ValueGeneratedOnAdd().HasDefaultValueSql("SEQ_PARTS.NEXTVAL")
            .HasConversion(x => x.Value, x => new PartId(x));
        builder.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Price).HasColumnName("PRICE").HasPrecision(5, 2)
            .HasConversion(x => x.Amount, x => new Money(x));
        builder.Property(x => x.Quantity).HasColumnName("QUANTITY").IsRequired();
        builder.Property(x => x.Quantity).IsConcurrencyToken();
        builder.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(1)
            .HasConversion(new ValueConverter<PartStatus, string>(x => PersistenceConversions.PartStatusToCode(x), x => PersistenceConversions.CodeToPartStatus(x)));
        builder.Property(x => x.PartTypeCode).HasColumnName("PARTTYPECODE").HasMaxLength(8).IsRequired();
        builder.HasIndex(x => x.Description).IsUnique();
    }
}

internal sealed class RepairConfiguration : IEntityTypeConfiguration<Repair>
{
    public void Configure(EntityTypeBuilder<Repair> builder)
    {
        builder.ToTable("REPAIRS");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("REPAIRID").ValueGeneratedOnAdd().HasDefaultValueSql("SEQ_REPAIRS.NEXTVAL")
            .HasConversion(x => x.Value, x => new RepairId(x));
        builder.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(200).IsRequired();
        builder.Property(x => x.PersistedStatus).HasColumnName("STATUS").HasMaxLength(2)
            .HasConversion(new ValueConverter<RepairStatus, string>(x => PersistenceConversions.RepairStatusToCode(x), x => PersistenceConversions.CodeToRepairStatus(x)));
        builder.Property(x => x.PersistedStatus).IsConcurrencyToken();
        builder.Property(x => x.Price).HasColumnName("PRICE").HasPrecision(6, 2)
            .HasConversion(new ValueConverter<Money?, decimal?>(
                x => x.HasValue ? x.Value.Amount : null,
                x => x.HasValue ? new Money(x.Value) : null));
        builder.Property(x => x.StartDate).HasColumnName("STARTDATE")
            .HasConversion(new ValueConverter<DateOnly?, string?>(
                x => PersistenceConversions.DateOnlyToOracleString(x),
                x => PersistenceConversions.OracleStringToDateOnly(x)));
        builder.Property(x => x.CompletedDate).HasColumnName("COMPLETEDATE")
            .HasConversion(new ValueConverter<DateOnly?, string?>(
                x => PersistenceConversions.DateOnlyToOracleString(x),
                x => PersistenceConversions.OracleStringToDateOnly(x)));
        builder.Ignore(x => x.ApprovedDate);
        builder.Ignore(x => x.CancelledDate);
        builder.Property(x => x.RepairTypeCode).HasColumnName("REPAIRTYPECODE").HasMaxLength(8).IsRequired();
        builder.Property(x => x.CustomerId).HasColumnName("CUSTID")
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
        builder.ToTable("REPAIRITEMS");
        builder.HasKey("RepairId", nameof(RepairItem.PartId));
        builder.Property<RepairId>("RepairId").HasColumnName("REPAIRID")
            .HasConversion(x => x.Value, x => new RepairId(x));
        builder.Property(x => x.PartId).HasColumnName("PARTID")
            .HasConversion(x => x.Value, x => new PartId(x));
        builder.Property(x => x.UnitPrice).HasColumnName("PRICE").HasPrecision(6, 2)
            .HasConversion(new ValueConverter<Money?, decimal?>(
                x => x.HasValue ? x.Value.Amount : null,
                x => x.HasValue ? new Money(x.Value) : Money.Zero));
        builder.Property(x => x.Quantity).HasColumnName("QUANTITYUSED");
        builder.Property<string>("Status").HasColumnName("STATUS").HasMaxLength(1).HasDefaultValue("U");
    }

}

using CPURepairSYS.Domain.Entities;
using CPURepairSYS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CPURepairSYS.Tests.Integration;

public sealed class PersistenceModelTests
{
    [Fact]
    public void ExistingSchemaTablesAndCompositeRepairItemKeyAreMapped()
    {
        var options = new DbContextOptionsBuilder<RepairDbContext>()
            .UseOracle("User Id=test;Password=test;Data Source=test")
            .Options;

        using var context = new RepairDbContext(options);
        var model = context.Model;

        Assert.Equal("Customers", model.FindEntityType(typeof(Customer))!.GetTableName());
        Assert.Equal("Parts", model.FindEntityType(typeof(Part))!.GetTableName());
        Assert.Equal("Repairs", model.FindEntityType(typeof(Repair))!.GetTableName());
        Assert.Equal("RepairItems", model.FindEntityType(typeof(RepairItem))!.GetTableName());
        Assert.Equal(2, model.FindEntityType(typeof(RepairItem))!.FindPrimaryKey()!.Properties.Count);
        Assert.Equal("SEQ_REPAIRS.NEXTVAL", model.FindEntityType(typeof(Repair))!
            .FindProperty(nameof(Repair.Id))!.GetDefaultValueSql());
    }
}
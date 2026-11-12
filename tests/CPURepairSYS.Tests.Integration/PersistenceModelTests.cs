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

        Assert.Equal("CUSTOMERS", model.FindEntityType(typeof(Customer))!.GetTableName());
        Assert.Equal("PARTS", model.FindEntityType(typeof(Part))!.GetTableName());
        Assert.Equal("REPAIRS", model.FindEntityType(typeof(Repair))!.GetTableName());
        Assert.Equal("REPAIRITEMS", model.FindEntityType(typeof(RepairItem))!.GetTableName());
        Assert.Equal(2, model.FindEntityType(typeof(RepairItem))!.FindPrimaryKey()!.Properties.Count);
        Assert.Equal("SEQ_REPAIRS.NEXTVAL", model.FindEntityType(typeof(Repair))!
            .FindProperty(nameof(Repair.Id))!.GetDefaultValueSql());
    }
}
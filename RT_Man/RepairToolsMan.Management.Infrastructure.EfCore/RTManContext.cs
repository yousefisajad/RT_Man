
using Microsoft.EntityFrameworkCore;
using RepairToolsMan.Domain.EquipmentAgg;
using RepairToolsMan.Domain.EquipmentCategoryAgg;
using RepairToolsMan.Management.Infrastructure.EfCore.EquipmentAgg.Configurations;
using RepairToolsMan.Management.Infrastructure.EfCore.EquipmentCategoryAgg;
using RepairToolsMan.Management.Infrastructure.EfCore.EquipmentCategoryAgg.Configurations;

namespace RepairToolsMan.Management.Infrastructure.EfCore
{
    public class RTManContext:DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentCategory> EquipmentCategories { get; set; }
        public RTManContext(DbContextOptions<RTManContext> op):base(op)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(EquipmentConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

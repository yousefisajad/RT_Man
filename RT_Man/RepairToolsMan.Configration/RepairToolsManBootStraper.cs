using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepairToolsMan.Application.Contracts.Equipment;
using RepairToolsMan.Application.Contracts.EquipmentCategory;
using RepairToolsMan.Application.Equipment;
using RepairToolsMan.Application.EquipmentCategory;
using RepairToolsMan.Domain.EquipmentAgg;
using RepairToolsMan.Domain.EquipmentCategoryAgg;
using RepairToolsMan.Management.Infrastructure.EfCore;
using RepairToolsMan.Management.Infrastructure.EfCore.EquipmentAgg.Repositories;
using RepairToolsMan.Management.Infrastructure.EfCore.EquipmentCategoryAgg.Repositories;

namespace RepairToolsMan.Configration
{
    public class RepairToolsManBootStraper
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddScoped<IEquipmentCategoryApplication, EquipmentCategoryApplication>();
            services.AddScoped<IEquipmentCategoryRepository, EquipmentCategoryRepository>();
            services.AddScoped<IEquipmentApplication, EquipmentAplication>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();


            services.AddDbContext<RTManContext>(op=>op.UseSqlServer(connectionString));

        }
    }
}

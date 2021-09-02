using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepairToolsMan.Application.Contracts.EquipmentCategory;
using RepairToolsMan.Application.EquipmentCategory;
using RepairToolsMan.Domain.EquipmentCategoryAgg;
using RepairToolsMan.Management.Infrastructure.EfCore;
using RepairToolsMan.Management.Infrastructure.EfCore.EquipmentCategoryAgg.Repositories;

namespace RepairToolsMan.Configration
{
    public class RepairToolsManBootStraper
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddScoped<IEquipmentCategoryApplication, EquipmentCategoryApplication>();
            services.AddScoped<IEquipmentCategoryRepository, EquipmentCategoryRepository>();
            services.AddDbContext<RTManContext>(op=>op.UseSqlServer(connectionString));

        }
    }
}

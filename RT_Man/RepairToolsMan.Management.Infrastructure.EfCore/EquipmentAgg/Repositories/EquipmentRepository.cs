
using FerameworkGeneral.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RepairToolsMan.Domain.EquipmentAgg;
using RepairToolsMan.Domain.EquipmentCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepairToolsMan.Management.Infrastructure.EfCore.EquipmentAgg.Repositories
{
    public class EquipmentRepository : RepositoryBase<long, Equipment>, IEquipmentRepository
    {
        readonly RTManContext _rmanContext;

        public EquipmentRepository(RTManContext rmanContext):base(rmanContext)
        {
            _rmanContext = rmanContext;
        }

     
        public List<Equipment> Search(Expression<Func<Equipment, bool>> expression = null)
        {
            if (expression == null)
                return _rmanContext.Equipments.Include(c=>c.EquipmentCategory).ToList();
            return _rmanContext.Equipments.Include(c => c.EquipmentCategory).Where(expression).ToList();
        }

        public Equipment GetDetails(long Id)
        {
            return _rmanContext.Equipments.Find(Id);
        }

        public List<EquipmentCategory> GetEquipmentCategories()
        {
            return _rmanContext.EquipmentCategories.ToList();
        }
    }
}

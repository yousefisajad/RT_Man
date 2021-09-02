
using RepairToolsMan.Domain.EquipmentCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepairToolsMan.Management.Infrastructure.EfCore.EquipmentCategoryAgg.Repositories
{
    public class EquipmentCategoryRepository : IEquipmentCategoryRepository
    {
        readonly RTManContext _rmanContext;

        public EquipmentCategoryRepository(RTManContext rmanContext)
        {
            _rmanContext = rmanContext;
        }

        public void Create(EquipmentCategory equipmentCategory)
        {
            _rmanContext.EquipmentCategories.Add(equipmentCategory);
        }

        public bool Exists(Expression<Func<EquipmentCategory, bool>> expression)
        {
            return _rmanContext.EquipmentCategories.Any(expression);
        }

        public List<EquipmentCategory> Get()
        {
            return _rmanContext.EquipmentCategories.ToList();
        }

        public EquipmentCategory Get(long Id)
        {
            return _rmanContext.EquipmentCategories.Find(Id);
        }


        public void SaveChanges()
        {
            _rmanContext.SaveChanges();

        }

        public List<EquipmentCategory> Search(Expression<Func<EquipmentCategory, bool>> expression = null)
        {
            if (expression == null)
                return _rmanContext.EquipmentCategories.ToList();
            return _rmanContext.EquipmentCategories.Where(expression).ToList();
        }

        public EquipmentCategory GetDetails(long Id)
        {
            return _rmanContext.EquipmentCategories.Find(Id);
        }
    }
}

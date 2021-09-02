
using FerameworkGeneral.Infrastructure;
using RepairToolsMan.Domain.EquipmentCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepairToolsMan.Management.Infrastructure.EfCore.EquipmentCategoryAgg.Repositories
{
    public class EquipmentCategoryRepository : RepositoryBase<long,EquipmentCategory>, IEquipmentCategoryRepository
    {
        readonly RTManContext _rmanContext;

        public EquipmentCategoryRepository(RTManContext rmanContext):base(rmanContext)
        {
            _rmanContext = rmanContext;
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

using FerameworkGeneral.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepairToolsMan.Domain.EquipmentCategoryAgg
{
    public interface IEquipmentCategoryRepository:IRepository<long,EquipmentCategory>
    {
 
        EquipmentCategory GetDetails(long Id);
        List <EquipmentCategory>Search(Expression<Func<EquipmentCategory, bool>> expression);
    }
}

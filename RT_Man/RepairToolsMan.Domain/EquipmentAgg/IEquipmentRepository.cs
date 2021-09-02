
using FerameworkGeneral.Domain;
using RepairToolsMan.Domain.EquipmentCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepairToolsMan.Domain.EquipmentAgg
{
    public interface IEquipmentRepository:IRepository<long,Equipment>
    {
        List<Equipment> Search(Expression<Func<Equipment, bool>> searchModel);
        List<EquipmentCategory> GetEquipmentCategories();
    }
}

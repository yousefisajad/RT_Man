
using FerameworkGeneral.Application;
using System.Collections.Generic;

namespace RepairToolsMan.Application.Contracts.EquipmentCategory
{
    public interface IEquipmentCategoryApplication
    {
        OperationResult Create(CreateEquipmentCategory command);
        OperationResult Edit(EditEquipmentCategory command);
        List<EquipmentCategoryViewModel > Search(EquipmentCategorySearchModel search);
        EditEquipmentCategory GetDetails(long id);
    }
}

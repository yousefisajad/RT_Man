

using FerameworkGeneral.Application;
using System.Collections.Generic;

namespace RepairToolsMan.Application.Contracts.Equipment
{
    public interface IEquipmentApplication
    {
        OperationResult Create(CreateEquipment command);
        OperationResult Edit(EditEquipment command);
        OperationResult SetIsInStore(long id);
        OperationResult SetNotInStore(long id);
        EditEquipment GetDetails(long id);
        List<EquipmentViewModel> Search(EquipmentSearchModel searchModel);
        List<EquipmentViewModel> GetCategories();


    }
}

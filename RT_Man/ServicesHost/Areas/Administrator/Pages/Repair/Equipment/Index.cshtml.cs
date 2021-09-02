using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerameworkGeneral.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairToolsMan.Application.Contracts.Equipment;

namespace ServicesHost.Areas.Administrator.Pages.Repair.Equipment
{
    public class IndexModel : PageModel
    {
        readonly IEquipmentApplication _equipmentApplication;
        public EquipmentSearchModel SearchModel;
        public SelectList equipmentCategories;
        public List<EquipmentViewModel> equipments;
        public IndexModel(IEquipmentApplication equipmentApplication)
        {
            _equipmentApplication = equipmentApplication;
        }

        public void OnGet(EquipmentSearchModel searchModel)
        {
            equipmentCategories=new SelectList(_equipmentApplication.GetCategories(),"Id","Name");
            equipments= _equipmentApplication.Search(searchModel);
        }


        public IActionResult OnGetCreate( )
        {
            return Partial("./Create",new CreateEquipment());
        }

        public JsonResult OnPostCreate(CreateEquipment create)
        {
            OperationResult result =_equipmentApplication.Create(create);
            return new JsonResult(result);
        }



        public IActionResult OnGetEdit(long id)
        {
            var category=_equipmentApplication.GetDetails(id);

            return Partial("./Edit", category);
        }

        public JsonResult OnPostEdit(EditEquipment command)
        {
            OperationResult result = _equipmentApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}

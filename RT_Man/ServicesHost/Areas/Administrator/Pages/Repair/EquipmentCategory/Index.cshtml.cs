using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerameworkGeneral.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepairToolsMan.Application.Contracts.EquipmentCategory;

namespace ServicesHost.Areas.Administrator.Pages.Repair.EquipmentCategory
{
    public class IndexModel : PageModel
    {
        readonly IEquipmentCategoryApplication _equipmentCategoryApplication;
        public EquipmentCategorySearchModel SearchModel;
        public IndexModel(IEquipmentCategoryApplication equipmentCategoryApplication)
        {
            _equipmentCategoryApplication = equipmentCategoryApplication;
        }
        public List<EquipmentCategoryViewModel > equipmentCategories;
        public void OnGet(EquipmentCategorySearchModel searchModel)
        {
            equipmentCategories= _equipmentCategoryApplication.Search(searchModel);
        }


        public IActionResult OnGetCreate( )
        {
            return Partial("./Create",new CreateEquipmentCategory());
        }

        public JsonResult OnPostCreate(CreateEquipmentCategory create)
        {
            OperationResult result =_equipmentCategoryApplication.Create(create);
            return new JsonResult(result);
        }



        public IActionResult OnGetEdit(long id)
        {
            var category=_equipmentCategoryApplication.GetDetails(id);

            return Partial("./Edit", category);
        }

        public JsonResult OnPostEdit(EditEquipmentCategory command)
        {
            OperationResult result = _equipmentCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}

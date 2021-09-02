using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}

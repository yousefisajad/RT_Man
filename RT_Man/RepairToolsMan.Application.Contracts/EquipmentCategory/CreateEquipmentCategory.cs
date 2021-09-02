using FerameworkGeneral.Application.Validations;
using System.ComponentModel.DataAnnotations;

namespace RepairToolsMan.Application.Contracts.EquipmentCategory
{
    public class CreateEquipmentCategory
    {
        [Required(ErrorMessage = ValidationMessages.RequiredText)]
        public string Name { get;  set; }

        public string Picture { get;  set; }
        public string Description { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.RequiredText)]
        public string KeyWord { get;  set; }

        [Required(ErrorMessage = ValidationMessages.RequiredText)]
        public string MetaDescription { get;  set; }

        [Required(ErrorMessage = ValidationMessages.RequiredText)]
        public string Slug { get;  set; }

    }
}

using _0_Framework.Application;
using FerameworkGeneral.Application;
using RepairToolsMan.Application.Contracts.EquipmentCategory;
using RepairToolsMan.Domain.EquipmentCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace RepairToolsMan.Application.EquipmentCategory
{
    public class EquipmentCategoryApplication : IEquipmentCategoryApplication
    {
        private readonly IEquipmentCategoryRepository _equipmentCategoryRepository;
        public EquipmentCategoryApplication(IEquipmentCategoryRepository equipmentCategoryRepository)
        {
            _equipmentCategoryRepository = equipmentCategoryRepository;
        }

        public OperationResult Create(CreateEquipmentCategory command)
        {

            var operationResil = new OperationResult();
            if (_equipmentCategoryRepository.Exists(c => c.Name == command.Name))
            {
                return operationResil.Fail("امکان ثبت رکورد تکراری وجود ندارد، لطفا مجدد تلاش کنید.");

            }

            var equipmentCategory = new Domain.EquipmentCategoryAgg.EquipmentCategory();
            var slug = command.Slug.Slugify();
            equipmentCategory.SetDescription(command.Description).
                SetKeyWord(command.KeyWord).SetmetaDescription(command.Description)
                .SetName(command.Name).SetPicture(command.Picture)
                .SetPictureAlt(command.PictureAlt).SetPictureTitle(command.PictureTitle)
                .SetSlug(slug);
            _equipmentCategoryRepository.Create(equipmentCategory);
            _equipmentCategoryRepository.SaveChanges();
            return operationResil.Success();

        }

        public OperationResult Edit(EditEquipmentCategory command)
        {
            var operationResil = new OperationResult();

            var eqCategory = _equipmentCategoryRepository.Get(command.Id);

            if (eqCategory == null)
            {
                return operationResil.Fail("رکوردی با اطلاعات دریافتی یافت نشد، لطفا مجدد تلاش کنید.");
            }

            if (_equipmentCategoryRepository.Exists(c => c.Name == command.Name && c.Id != command.Id))
            {
                return operationResil.Fail("امکان ثبت رکورد تکراری وجود ندارد، لطفا مجدد تلاش کنید.");
            }

            var slug = command.Slug.Slugify();
            eqCategory.SetDescription(command.Description).
                           SetKeyWord(command.KeyWord).SetmetaDescription(command.Description)
                           .SetName(command.Name).SetPicture(command.Picture)
                           .SetPictureAlt(command.PictureAlt).SetPictureTitle(command.PictureTitle)
                           .SetSlug(slug);

            _equipmentCategoryRepository.SaveChanges();
            return operationResil.Success();
        }

        public EditEquipmentCategory GetDetails(long id)
        {
            var eqCat = _equipmentCategoryRepository.GetDetails(id);
            if (eqCat == null)
            {
                return null;
            }
            var editEqCat = new EditEquipmentCategory()
            {
                Description = eqCat.Description,
                KeyWord = eqCat.KeyWord,
                MetaDescription = eqCat.MetaDescription,
                Name = eqCat.Name,
                Id = eqCat.Id,
                Picture = eqCat.Picture,
                PictureAlt = eqCat.PictureAlt,
                PictureTitle = eqCat.PictureTitle,
                Slug = eqCat.Slug
            };
            return editEqCat;
        }

        public List<EquipmentCategoryViewModel> Search(EquipmentCategorySearchModel search)
        {
            var searchItems = new List<EquipmentCategoryViewModel>();
            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                searchItems = _equipmentCategoryRepository.Search(c => c.Name.Contains(search.Name)).
                 Select(c => new EquipmentCategoryViewModel
                 {
                     Name = c.Name,
                     Id = c.Id,
                     InsertDate = c.InsertDate.ToString(),
                     Picture = c.Picture
                 }).ToList();

            }
            else
            {
                searchItems = _equipmentCategoryRepository.Search(null).
                 Select(c => new EquipmentCategoryViewModel
                 {
                     Name = c.Name,
                     Id = c.Id,
                     InsertDate = c.InsertDate.ToString(),
                     Picture = c.Picture
                 }).ToList();
            }
            return searchItems.OrderByDescending(c => c.Id).ToList();

        }
    }
}

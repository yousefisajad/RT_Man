
using _0_Framework.Application;
using FerameworkGeneral.Application;
using FerameworkGeneral.Application.Validations;
using RepairToolsMan.Application.Contracts.Equipment;
using RepairToolsMan.Domain.EquipmentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepairToolsMan.Application.Equipment
{
    public class EquipmentAplication : IEquipmentApplication
    {
        readonly IEquipmentRepository _equipmentRepository;

        public EquipmentAplication(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public OperationResult Create(CreateEquipment command)
        {
            var operationResult = new OperationResult();


            if (_equipmentRepository.Exists(c => c.Name == command.Name))
            {
                return operationResult.Fail(ApplicationMessages.DuplicatedRecord);
            }
            var slug = command.Slug.Slugify();

            var eqipments = new Domain.EquipmentAgg.Equipment();
            eqipments.SetName(command.Name).SetCode(command.Code)
                .SetCategoryId(command.CategoryId).SetDescription(command.Description)
                .SetKeyWord(command.KeyWords).SetMetaDescription(command.MetaDescription)
                .SetPicture(command.Picture).SetPictureAlt(command.PictureAlt)
                .SetPictureTitle(command.PictureTitle).SetShortDescription(command.ShortDescription)
                .SetSlug(slug).SetUnitPrice(command.UnitPrice);

            _equipmentRepository.Create(eqipments);
            _equipmentRepository.SaveChanges();
            return operationResult.Success();

        }

        public OperationResult Edit(EditEquipment command)
        {
            var operationResil = new OperationResult();

            var eqipments = _equipmentRepository.Get(command.Id);

            if (eqipments == null)
            {
                return operationResil.Fail(ApplicationMessages.RecordNotFound);
            }

            if (_equipmentRepository.Exists(c => c.Name == command.Name && c.Id != command.Id))
            {
                return operationResil.Fail(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            eqipments.SetName(command.Name).SetCode(command.Code)
                        .SetCategoryId(command.CategoryId).SetDescription(command.Description)
                        .SetKeyWord(command.KeyWords).SetMetaDescription(command.MetaDescription)
                        .SetPicture(command.Picture).SetPictureAlt(command.PictureAlt)
                        .SetPictureTitle(command.PictureTitle).SetShortDescription(command.ShortDescription)
                        .SetSlug(slug).SetUnitPrice(command.UnitPrice);

            _equipmentRepository.SaveChanges();
            return operationResil.Success();
        }

        public List<EquipmentViewModel> GetCategories()
        {
            var categories=_equipmentRepository.GetEquipmentCategories();
            return categories.Select(c=>new EquipmentViewModel()
            {
                Name=c.Name,
                Id=c.Id
            }).ToList();
        }

        public EditEquipment GetDetails(long id)
        {
            var eqCat = _equipmentRepository.Get(id);
            var editEqCat = new EditEquipment()
            {
                Description = eqCat.Description,
                KeyWords = eqCat.KeyWords,
                MetaDescription = eqCat.MetaDescription,
                Name = eqCat.Name,
                Id = eqCat.Id,
                Picture = eqCat.Picture,
                PictureAlt = eqCat.PictureAlt,
                PictureTitle = eqCat.PictureTitle,
                Slug = eqCat.Slug,
                CategoryId = eqCat.CategoryId,
                Code = eqCat.Code,
                ShortDescription = eqCat.ShortDescription,
                UnitPrice = eqCat.UnitPrice
            };
            return editEqCat;
        }

        public List<EquipmentViewModel> Search(EquipmentSearchModel searchModel)
        {
            var searchItems = new List<EquipmentViewModel>();

            if (!string.IsNullOrWhiteSpace(searchModel.Name) || !string.IsNullOrWhiteSpace(searchModel.Code) ||
                searchModel.CategoryId > 0)
            {
                Expression<Func<Domain.EquipmentAgg.Equipment, bool>> searchConditions =
               c => (!string.IsNullOrWhiteSpace(searchModel.Name) && searchModel.Name.Contains(c.Name))
                || (!string.IsNullOrWhiteSpace(searchModel.Code) && searchModel.Code.Contains(c.Code))
                || (searchModel.CategoryId > 0 && searchModel.CategoryId == c.CategoryId);

                searchItems = _equipmentRepository.Search(searchConditions).
                 Select(c => new EquipmentViewModel
                 {
                     Name = c.Name,
                     Id = c.Id,
                     Picture = c.Picture,
                     Code = c.Code,
                     Category = c.EquipmentCategory.ToString(),
                     unitPrice = c.UnitPrice,
                     CategoryId = c.CategoryId,
                     InsertDate = c.InsertDate.ToString()
                 }).ToList();

            }
            else
            {
                searchItems = _equipmentRepository.Search(null).
                 Select(c => new EquipmentViewModel
                 {
                     Name = c.Name,
                     Id = c.Id,
                     Picture = c.Picture,
                     Code = c.Code,
                     Category = c.EquipmentCategory.ToString(),
                     unitPrice = c.UnitPrice,
                     CategoryId = c.CategoryId,
                     InsertDate = c.InsertDate.ToString()
                 }).ToList();
            }
            return searchItems.OrderByDescending(c => c.Id).ToList();
        }

        public OperationResult SetIsInStore(long id)
        {
            var operationResult = new OperationResult();

            var eqipments = _equipmentRepository.Get(id);

            if (eqipments == null)
            {
                return operationResult.Fail(ApplicationMessages.RecordNotFound);
            }
            eqipments.SetIsInStore(true);
            return operationResult.Success();
        }

        public OperationResult SetNotInStore(long id)
        {
            var operationResult = new OperationResult();

            var eqipments = _equipmentRepository.Get(id);

            if (eqipments == null)
            {
                return operationResult.Fail(ApplicationMessages.RecordNotFound);
            }
            eqipments.SetIsInStore(false);
            return operationResult.Success();
        }
    }
}

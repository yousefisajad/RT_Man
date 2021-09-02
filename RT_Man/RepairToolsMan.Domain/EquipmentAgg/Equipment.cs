
using FerameworkGeneral.Domain;
using RepairToolsMan.Domain.EquipmentCategoryAgg;

namespace RepairToolsMan.Domain.EquipmentAgg
{
    public class Equipment: BaseEntity
    {
        public Equipment()
        {
            IsInStore=true;
            
        }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public long UnitPrice { get; private set; }
        public bool IsInStore { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public long CategoryId { get; private set; }
        public EquipmentCategory EquipmentCategory { get; set; }


        public Equipment SetName(string name)
        {
            Name = name;
            return this;
        }
        public Equipment SetCode(string code)
        {
            Code = code;
            return this;
        }
        public Equipment SetUnitPrice(long unitPrice)
        {
            UnitPrice = unitPrice;
            return this;
        }
        public Equipment SetIsInStore(bool isInStore)
        {
            IsInStore = isInStore;
            return this;
        }
        public Equipment SetDescription(string description)
        {
            Description = description;
            return this;
        }
        public Equipment SetShortDescription(string shortdescription)
        {
            ShortDescription = shortdescription;
            return this;
        }

        public Equipment SetPicture(string picture)
        {
            Picture = picture;
            return this;
        }

        public Equipment SetPictureAlt(string pictureAlt)
        {
            PictureAlt = pictureAlt;
            return this;
        }

        public Equipment SetPictureTitle(string pictureTitle)
        {
            PictureTitle = pictureTitle;
            return this;
        }

        public Equipment SetKeyWord(string keyWords)
        {
            KeyWords = keyWords;
            return this;
        }
        public Equipment SetSlug(string slug)
        {
            Slug = slug;
            return this;
        }
        public Equipment SetMetaDescription(string metaDescription)
        {
            MetaDescription = metaDescription;
            return this;
        }

        public Equipment SetCategoryId(long categoryId)
        {
            CategoryId = categoryId;
            return this;
        }

    }
}

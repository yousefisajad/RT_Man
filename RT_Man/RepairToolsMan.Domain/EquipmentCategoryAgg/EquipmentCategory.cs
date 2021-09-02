using FerameworkGeneral.Domain;
using RepairToolsMan.Domain.EquipmentAgg;
using System.Collections.Generic;

namespace RepairToolsMan.Domain.EquipmentCategoryAgg
{
    public class EquipmentCategory : BaseEntity
    {
        public EquipmentCategory()
        {
            Equipments=new List<Equipment>();
        }
        public string Name { get; private set; }

        public string Picture { get; private set; }
        public string Description { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public List<Equipment> Equipments { get; set; }

        public EquipmentCategory SetName(string name)
        {
            Name = name;
            return this;
        }

        public EquipmentCategory SetPicture(string picture)
        {
            Picture = picture;
            return this;
        }

        public EquipmentCategory SetPictureAlt(string pictureAlt)
        {
            PictureAlt = pictureAlt;
            return this;
        }

        public EquipmentCategory SetPictureTitle(string pictureTitle)
        {
            PictureTitle = pictureTitle;
            return this;
        }

        public EquipmentCategory SetDescription(string description)
        {
            Description = description;
            return this;
        }
        public EquipmentCategory SetKeyWord(string keyWord)
        {
            KeyWords = keyWord;
            return this;
        }
        public EquipmentCategory SetSlug(string slug)
        {
            Slug = slug;
            return this;
        }
        public EquipmentCategory SetMetaDescription(string metaDescription)
        {
            MetaDescription = metaDescription;
            return this;
        }
    }
}

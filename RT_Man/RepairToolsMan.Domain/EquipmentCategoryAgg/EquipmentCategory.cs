using FerameworkGeneral.Domain;

namespace RepairToolsMan.Domain.EquipmentCategoryAgg
{
    public class EquipmentCategory : BaseEntity
    {
        public string Name { get; private set; }

        public string Picture { get; private set; }
        public string Description { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWord { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }


        public EquipmentCategory SetName(string name)
        {
            Name=name;
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
            KeyWord = keyWord;
            return this;
        }
        public EquipmentCategory SetSlug(string slug)
        {
            Slug = slug;
            return this;
        }
        public EquipmentCategory SetmetaDescription(string metaDescription)
        {
            MetaDescription = metaDescription;
            return this;
        }
    }
}

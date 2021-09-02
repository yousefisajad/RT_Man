using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairToolsMan.Application.Contracts.Equipment
{
    public class CreateEquipment
    {
        public string Name { get;  set; }
        public string Code { get;  set; }
        public long UnitPrice { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string KeyWords { get;  set; }
        public string MetaDescription { get;  set; }
        public string Slug { get;  set; }
        public long CategoryId { get;  set; }


    }
}

using System;

namespace FerameworkGeneral.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            InsertDate=DateTime.Now;
        }
        public long Id { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime?  DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

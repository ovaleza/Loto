using System;

namespace Loto.Domain.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.DateCreated = DateTime.Now;
            this.IsActive = true;
            this.IsDeleted = false;
        }
        public int? IdUserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? IdUserModified { get; set; }
        public DateTime? DateModified { get; set; }
        = DateTime.Now;
        public int? IdUserDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
    }
}

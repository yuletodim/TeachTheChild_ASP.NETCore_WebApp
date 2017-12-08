namespace TeachTheChild.Data.Models.Common
{
    using System;

    public abstract class BaseModel : IAuditInfo
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

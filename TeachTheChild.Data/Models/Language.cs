namespace TeachTheChild.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

    public class Language : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Culture { get; set; }

        public IEnumerable<User> Users { get; set; } = new List<User>();
    }
}

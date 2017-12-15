namespace TeachTheChild.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

    public class Country : BaseModel
    {
        [Required]
        [MinLength(DataConstants.CountryMinLength)]
        [MaxLength(DataConstants.CountryMaxLength)]
        public string Name { get; set; }

        public string Flag { get; set; }

        public string FlagUrl { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}

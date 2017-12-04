namespace TeachTheChild.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.CountryMinLength)]
        [MaxLength(DataConstants.CountryMaxLength)]
        public string Name { get; set; }

        public string Flag { get; set; }

        public string FlagUrl { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}

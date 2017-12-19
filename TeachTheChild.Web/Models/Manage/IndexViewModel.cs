namespace TeachTheChild.Web.Models.Manage
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Global.Models;

    public class IndexViewModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public bool EmailConfirmed { get; set; }

        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        public int CountryId { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public IEnumerable<CountryShortModel> Countries { get; set; }

        public IEnumerable<LanguageShortModel> Languages { get; set; }
    }
}

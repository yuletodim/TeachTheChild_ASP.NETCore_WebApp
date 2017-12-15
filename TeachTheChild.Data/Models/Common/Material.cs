namespace TeachTheChild.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    public abstract class Material : BaseModel
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}

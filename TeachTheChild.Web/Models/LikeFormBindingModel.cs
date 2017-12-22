namespace TeachTheChild.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LikeFormBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsLike { get; set; }
    }
}

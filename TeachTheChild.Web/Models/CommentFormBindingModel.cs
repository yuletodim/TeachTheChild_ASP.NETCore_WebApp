namespace TeachTheChild.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentFormBindingModel
    {
        [Required]
        public int Id { get; set; }

        public int? CommentId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}

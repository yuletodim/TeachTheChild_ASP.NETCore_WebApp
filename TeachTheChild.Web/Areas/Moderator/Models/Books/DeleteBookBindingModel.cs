namespace TeachTheChild.Web.Areas.Moderator.Models.Books
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteBookBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}

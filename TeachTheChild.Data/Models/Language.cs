namespace TeachTheChild.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Articles;
    using TeachTheChild.Data.Models.Books;
    using TeachTheChild.Data.Models.Common;
    using TeachTheChild.Data.Models.DownloadMaterials;
    using TeachTheChild.Data.Models.Videos;

    public class Language : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Culture { get; set; }

        public List<User> Users { get; set; } = new List<User>();

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<Book> Books { get; set; } = new List<Book>();

        public List<Video> Videos { get; set; } = new List<Video>();
       
        public List<DownloadMaterial> DownloadMaterials { get; set; } = new List<DownloadMaterial>();
    }
}

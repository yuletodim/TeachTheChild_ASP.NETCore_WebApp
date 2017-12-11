namespace TeachTheChild.Data.Models.Comments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Answers;
    using TeachTheChild.Data.Models.Materials;

    public class ArticleComment : Comment
    {
        [Required]
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public List<ArticleCommentAnswer> Answers { get; set; } = new List<ArticleCommentAnswer>();
    }
}

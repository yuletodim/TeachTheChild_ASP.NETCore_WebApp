﻿namespace TeachTheChild.Data.Models.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

    public class Article : Material
    {
        [Required]
        [MinLength(DataConstants.ArticleTitleMinLength)]
        [MaxLength(DataConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.ArticleContentMinLength)]
        public string Content { get; set; }

        public List<ArticleComment> Comments { get; set; } = new List<ArticleComment>();

        public List<ArticleLike> Likes { get; set; } = new List<ArticleLike>();
    }
}

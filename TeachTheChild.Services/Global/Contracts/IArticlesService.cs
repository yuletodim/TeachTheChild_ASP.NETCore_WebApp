﻿namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models.Articles;

    public interface IArticlesService
    {
        Task<IEnumerable<ArticleShortModel>> GetLastTreeAsync();
    }
}
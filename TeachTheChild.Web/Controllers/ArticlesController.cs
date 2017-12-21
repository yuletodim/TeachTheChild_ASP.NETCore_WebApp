namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Models.Articles;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var articles = await this.articlesService.GetPortionAsync(page, WebConstants.ArticlesPageSize);
            var pagesCount = (int)Math.Ceiling(await this.articlesService.GetTotalCountAsync() / (double)WebConstants.ArticlesPageSize);

            var data = new ArticlesPagingViewModel
            {
                Articles = articles,
                CurrentPage = page,
                PagesCount = pagesCount
            };

            return View(data);
        }

        public async Task<IActionResult> Details(int id)
            => this.View(await this.articlesService.GetByIdAsync(id));
    }
}

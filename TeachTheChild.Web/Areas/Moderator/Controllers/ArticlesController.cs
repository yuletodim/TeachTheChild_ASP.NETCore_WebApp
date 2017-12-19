namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TeachTheChild.Services.Html;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models;
    using TeachTheChild.Web.Models;

    public class ArticlesController : BaseModeratorControler
    {
        private IArticlesModeratorService articlesService;
        private readonly IHtmlService htmlServise;

        public ArticlesController(IArticlesModeratorService articlessService, IHtmlService htmlServise)
        {
            this.articlesService = articlessService;
            this.htmlServise = htmlServise;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult LoadDatatableAjax(DTParameters param)
        {
            int count = 0;

            var data = this.articlesService.GetFilteredPortion(
                param.Length,
                param.Start,
                param.SortColumnName,
                param.SortDirection,
                param.Search.Value,
                out count);

            var result = new DTResult<ArticleTableModeratorModel>
            {
                draw = param.Draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };

            return this.Json(result);
        }
    }
}

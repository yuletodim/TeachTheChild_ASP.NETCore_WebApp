namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Html;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models.Articles;
    using TeachTheChild.Web.Areas.Moderator.Models.Articles;
    using TeachTheChild.Web.Infrastructure.Filters;
    using TeachTheChild.Web.Models;

    public class ArticlesController : BaseModeratorControler
    {
        private readonly IArticlesModeratorService articlesService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IHtmlService htmlServise;

        public ArticlesController(IArticlesModeratorService articlessService,
            UserManager<User> userManager,
            IMapper mapper,
            IHtmlService htmlServise)
        {
            this.articlesService = articlessService;
            this.userManager = userManager;
            this.mapper = mapper;
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

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublishArticleBindingModel model)
        {
            model.Content = this.htmlServise.Sanitize(model.Content);
            model.UserId = this.userManager.GetUserId(this.User);

            var article = this.mapper.Map<AddArticleModel>(model);

            await this.articlesService.AddAsync(article);

            return this.RedirectToAction(nameof(Index));
        }
    }
}

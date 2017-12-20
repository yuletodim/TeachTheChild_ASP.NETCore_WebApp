namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Html;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models.Articles;
    using TeachTheChild.Web.Areas.Moderator.Models.Articles;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Infrastructure.Extensions;
    using TeachTheChild.Web.Infrastructure.Filters;
    using TeachTheChild.Web.Models;

    public class ArticlesController : BaseModeratorControler
    {
        private readonly IArticlesModeratorService articlesService;
        private readonly IUsersService usersService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IHtmlService htmlServise;

        public ArticlesController(
            IArticlesModeratorService articlessService,
            IUsersService usersService,
            UserManager<User> userManager,
            IMapper mapper,
            IHtmlService htmlServise)
        {
            this.articlesService = articlessService;
            this.usersService = usersService;
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

            model.LanguageId = await this.usersService.GetUserLanguageIdAsync(model.UserId);
            if (model.LanguageId == 0)
            {
                TempData.AddErrorMessage(WebConstants.PublishArticleError);
                return this.View(model);
            }
            var article = this.mapper.Map<ArticleFormModel>(model);
            var result = await this.articlesService.AddAsync(article);
            if (result == 0)
            {
                TempData.AddErrorMessage(WebConstants.PublishArticleError);
                return this.View(model);
            }

            TempData.AddSuccessMessage(WebConstants.PublishArticleSuccess);

            return this.RedirectToAction(
                nameof(TeachTheChild.Web.Controllers.ArticlesController.Details), 
                "Articles", 
                new { area = "", id = result, title = model.Title.ToFriendlyUrl() });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var userPermissions = await this.articlesService.IsArticleFromUserAsync(id, userId);
            if (!userPermissions)
            {
                TempData.AddInfoMessage(WebConstants.UserNoPermissionsEdit);
                return this.RedirectToAction(nameof(Index));
            }

            var article = await this.articlesService.GetByIdAsync(id);
            var model = this.mapper.Map<PublishArticleBindingModel>(article);

            return this.View(model);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(PublishArticleBindingModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            var userPermissions = await this.articlesService.IsArticleFromUserAsync(model.Id, userId);
            if (!userPermissions)
            {
                TempData.AddInfoMessage(WebConstants.UserNoPermissionsEdit);
                return this.RedirectToAction(nameof(Index));
            }

            model.Content = this.htmlServise.Sanitize(model.Content);
            var article = this.mapper.Map<ArticleFormModel>(model);
            var result = await this.articlesService.EditAsync(article);

            if (!result)
            {
                TempData.AddErrorMessage(WebConstants.PublishArticleError);
                return this.View(model);
            }

            TempData.AddSuccessMessage(WebConstants.PublishArticleSuccess);

            return this.RedirectToAction(
                nameof(TeachTheChild.Web.Controllers.ArticlesController.Details), 
                "Articles",
                new { area = "", id = model.Id, title = model.Title.ToFriendlyUrl() });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]DeleteArticleBindingModel model)
        {
            var result = await this.articlesService.DeleteAsync(model.Id);

            return this.Json(new { success = result });
        }
    }
}

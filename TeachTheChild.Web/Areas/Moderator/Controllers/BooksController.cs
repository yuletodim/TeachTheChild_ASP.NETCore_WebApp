namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models.Books;
    using TeachTheChild.Web.Areas.Moderator.Models.Books;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Infrastructure.Extensions;
    using TeachTheChild.Web.Infrastructure.Filters;
    using TeachTheChild.Web.Infrastructure.Helpers;
    using TeachTheChild.Web.Models;

    public class BooksController : BaseModeratorControler
    {
        private readonly IBooksModeratorService booksService;
        private readonly IUsersService usersService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;

        public BooksController(
            IBooksModeratorService booksService, 
            UserManager<User> userManager,
            IUsersService usersService,
            IMapper mapper,
            IHostingEnvironment hostingEnvironment)
        {
            this.booksService = booksService;
            this.userManager = userManager;
            this.usersService = usersService;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
        }

        private string RootPath
        {
            get
            {
                return this.hostingEnvironment.WebRootPath;
            }
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult LoadDatatableAjax(DTParameters param)
        {
            int count = 0;

            var data = this.booksService.GetFilteredPortion(
                param.Length,
                param.Start,
                param.SortColumnName,
                param.SortDirection,
                param.Search.Value,
                out count);

            var result = new DTResult<BookTableModeratorModel>
            {
                draw = param.Draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };

            return this.Json(result);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Add(BookFormBindingModel model)
        {
            model.UserId = this.userManager.GetUserId(this.User);
            model.LanguageId = await this.usersService.GetUserLanguageIdAsync(model.UserId);

            if (model.LanguageId == 0)
            {
                TempData.AddErrorMessage(WebConstants.SaveDownloadsError);
                return this.View(model);
            }

            if (model.File != null)
            {
                if (!(model.File.ContentType == WebConstants.JpgMimeType
                || model.File.ContentType == WebConstants.PngMimeType))
                {
                    TempData.AddErrorMessage(WebConstants.NotSupportedFile);
                    return this.View(model);
                }

                model.PictureUrl = await model.File.SaveToFileSystem(this.RootPath, WebConstants.BooksFolder);
            }
            
            var book = this.mapper.Map<BookFormModel>(model);
            var result = await this.booksService.AddAsync(book);
            if (result == 0)
            {
                TempData.AddErrorMessage(WebConstants.SaveBookError);
                return this.View(model);
            }

            TempData.AddSuccessMessage(WebConstants.SaveBookSuccess);
            return this.RedirectToAction(nameof(TeachTheChild.Web.Controllers.BooksController.Details),
                "Books",
                new { area = "", id = result, title = model.Title.ToFriendlyUrl() });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await this.booksService.GetByIdAsync(id);
            if (book == null)
            {
                return this.NotFound();
            }

            var model = this.mapper.Map<BookFormBindingModel>(book);

            return this.View(model);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Edit(BookFormBindingModel model)
        {
            if (model.File != null)
            {
                if (!(model.File.ContentType == WebConstants.JpgMimeType
                || model.File.ContentType == WebConstants.PngMimeType))
                {
                    TempData.AddErrorMessage(WebConstants.NotSupportedFile);
                    return this.View(model);
                }

                var filePath = await this.booksService.GetPictureUrlByIdAsync(model.Id);
                model.PictureUrl = await model.File.SaveToFileSystem(this.RootPath, WebConstants.BooksFolder, filePath );
            }

            var book = this.mapper.Map<BookFormModel>(model);
            var result = await this.booksService.EditAsync(book);

            if (!result)
            {
                TempData.AddErrorMessage(WebConstants.SaveBookError);
                return this.View(model);
            }

            TempData.AddSuccessMessage(WebConstants.SaveBookSuccess);

            return this.RedirectToAction(
                nameof(TeachTheChild.Web.Controllers.ArticlesController.Details),
                "Books",
                new { area = "", id = model.Id, title = model.Title.ToFriendlyUrl() });
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]DeleteBookBindingModel model)
        {
            var pictureUrl = await this.booksService.GetPictureUrlByIdAsync(model.Id);
            if (pictureUrl == null)
            {
                return this.BadRequest(WebConstants.DeleteDownloadPictureEror);
            }

            var result = FileHelpers.Delete($"{this.RootPath}{pictureUrl}");
            if (!result)
            {
                return this.BadRequest(WebConstants.DeleteDownloadPictureEror);
            }

            result = await this.booksService.DeleteAsync(model.Id);

            return this.Json(new { success = result });
        }
    }
}

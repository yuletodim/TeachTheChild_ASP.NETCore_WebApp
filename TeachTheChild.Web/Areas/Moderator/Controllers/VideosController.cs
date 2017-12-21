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
    using TeachTheChild.Services.Moderator.Models.Videos;
    using TeachTheChild.Web.Areas.Moderator.Models.Videos;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Infrastructure.Extensions;
    using TeachTheChild.Web.Infrastructure.Filters;
    using TeachTheChild.Web.Infrastructure.Helpers;
    using TeachTheChild.Web.Models;

    public class VideosController : BaseModeratorControler
    {
        private readonly IVideosModeratorService videosService;
        private readonly IUsersService usersService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;

        public VideosController(
            IVideosModeratorService videosService, 
            UserManager<User> userManager,
            IUsersService usersService,
            IMapper mapper,
            IHostingEnvironment hostingEnvironment)
        {
            this.videosService = videosService;
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

            var data = this.videosService.GetFilteredPortion(
                param.Length,
                param.Start,
                param.SortColumnName,
                param.SortDirection,
                param.Search.Value,
                out count);

            var result = new DTResult<VideoTableModeratorModel>
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
        public async Task<IActionResult> Add(VideoFormBindingModel model)
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
                if (!(model.File.ContentType == WebConstants.Mp4MimeType
                || model.File.ContentType == WebConstants.PngMimeType))
                {
                    TempData.AddErrorMessage(WebConstants.NotSupportedFile);
                    return this.View(model);
                }

                model.Url = await model.File.SaveToFileSystem(this.RootPath, WebConstants.VideosFolder);
            }

            var book = this.mapper.Map<VideoFormModel>(model);
            var result = await this.videosService.AddAsync(book);
            if (result == 0)
            {
                TempData.AddErrorMessage(WebConstants.SaveBookError);
                return this.View(model);
            }

            TempData.AddSuccessMessage(WebConstants.SaveBookSuccess);
            return this.RedirectToAction(nameof(TeachTheChild.Web.Controllers.VideosController.Index),
                "Videos",
                new { area = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]DeleteVideoBindingModel model)
        {
            var pictureUrl = await this.videosService.GetUrlByIdAsync(model.Id);
            if (pictureUrl == null)
            {
                return this.BadRequest(WebConstants.DeleteDownloadPictureEror);
            }

            var result = FileHelpers.Delete($"{this.RootPath}{pictureUrl}");
            if (!result)
            {
                return this.BadRequest(WebConstants.DeleteDownloadPictureEror);
            }

            result = await this.videosService.DeleteAsync(model.Id);

            return this.Json(new { success = result });
        }
    }
}

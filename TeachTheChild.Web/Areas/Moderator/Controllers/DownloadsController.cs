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
    using TeachTheChild.Services.Moderator.Models.Downloads;
    using TeachTheChild.Web.Areas.Moderator.Models.DownloadMaterials;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Infrastructure.Extensions;
    using TeachTheChild.Web.Infrastructure.Filters;
    using TeachTheChild.Web.Infrastructure.Helpers;
    using TeachTheChild.Web.Models;

    public class DownloadsController : BaseModeratorControler
    {
        private readonly IDownloadMaterialsModeratorService downloadsService;
        private readonly IUsersService usersService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;

        public DownloadsController(
            IDownloadMaterialsModeratorService downloadsService, 
            UserManager<User> userManager,
            IUsersService usersService,
            IMapper mapper,
            IHostingEnvironment hostingEnvironment)
        {
            this.downloadsService = downloadsService;
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

            var data = this.downloadsService.GetFilteredPortion(
                param.Length,
                param.Start,
                param.SortColumnName,
                param.SortDirection,
                param.Search.Value,
                out count);

            var result = new DTResult<DownloadsTableModeratorModel>
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
        public async Task<IActionResult> Add(DownloadsFormBindingModel model)
        {
            model.UserId = this.userManager.GetUserId(this.User);
            model.LanguageId = await this.usersService.GetUserLanguageIdAsync(model.UserId);

            if (model.LanguageId == 0)
            {
                TempData.AddErrorMessage(WebConstants.SaveDownloadsError);
                return this.View(model);
            }

            if (!(model.File.ContentType == WebConstants.JpgMimeType 
                || model.File.ContentType == WebConstants.PngMimeType))
            {
                TempData.AddErrorMessage(WebConstants.NotSupportedFile);
                return this.View(model);
            }

            model.PictureUrl = await model.File.SaveToFileSystem(this.RootPath, WebConstants.DownloadsFolder);

            var downloads = this.mapper.Map<DownloadsFormModel>(model);
            var result = await this.downloadsService.AddAsync(downloads);
            if (result == 0)
            {
                TempData.AddErrorMessage(WebConstants.SaveDownloadsError);
                return this.View(model);
            }

            TempData.AddSuccessMessage(WebConstants.SaveDownloadsSuccess);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]DeleteDownloadsBindingModel model)
        {
            var pictureUrl = await this.downloadsService.GetPictureUrlByIdAsync(model.Id);
            if (pictureUrl == null)
            {
                return this.BadRequest(WebConstants.DeleteDownloadPictureEror);
            }

            var result = FileHelpers.Delete($"{this.RootPath}{pictureUrl}");
            if(!result)
            {
                return this.BadRequest(WebConstants.DeleteDownloadPictureEror);
            }

            result = await this.downloadsService.DeleteAsync(model.Id);

            return this.Json(new { success = result });
        }
    }
}

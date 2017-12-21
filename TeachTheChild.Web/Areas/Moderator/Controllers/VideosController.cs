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

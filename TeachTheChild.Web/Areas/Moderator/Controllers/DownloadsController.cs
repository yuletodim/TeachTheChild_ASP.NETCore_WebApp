namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models;
    using TeachTheChild.Services.Moderator.Models.Downloads;
    using TeachTheChild.Web.Models;

    public class DownloadsController : BaseModeratorControler
    {
        private readonly IDownloadMaterialsModeratorService downloadsService;
        private readonly UserManager<User> userManager;

        public DownloadsController(
            IDownloadMaterialsModeratorService downloadsService, 
            UserManager<User> userManager)
        {
            this.downloadsService = downloadsService;
            this.userManager = userManager;
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
    }
}

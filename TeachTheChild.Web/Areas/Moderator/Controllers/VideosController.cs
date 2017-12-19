namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models;
    using TeachTheChild.Services.Moderator.Models.Videos;
    using TeachTheChild.Web.Models;

    public class VideosController : BaseModeratorControler
    {
        private readonly IVideosModeratorService videosService;
        private readonly UserManager<User> userManager;

        public VideosController(IVideosModeratorService videosService, UserManager<User> userManager)
        {
            this.videosService = videosService;
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
    }
}

namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Moderator.Contracts;

    public class VideosController : BaseModeratorControler
    {
        private IVideosModeratorService videosService;

        public VideosController(IVideosModeratorService videosService)
        {
            this.videosService = videosService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}

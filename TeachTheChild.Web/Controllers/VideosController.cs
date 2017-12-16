namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Contracts;

    public class VideosController : BaseController
    {
        private readonly IVideosService videosService;

        public VideosController(IVideosService videosService)
        {
            this.videosService = videosService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}

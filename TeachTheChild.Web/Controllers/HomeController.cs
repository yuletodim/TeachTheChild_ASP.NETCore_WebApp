namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Models;
    using TeachTheChild.Web.Models.Home;

    public class HomeController : Controller
    {
        private readonly IArticlesService articlesService;
        private readonly IBooksService booksService;
        private readonly IVideosService videosService;
        private readonly IDownloadMaterialsService downloadsService;

        public HomeController(
            IArticlesService articlesService,
            IBooksService booksService,
            IVideosService videosService,
            IDownloadMaterialsService downloadsService)
        {
            this.articlesService = articlesService;
            this.booksService = booksService;
            this.videosService = videosService;
            this.downloadsService = downloadsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel
            {
                Articles = await this.articlesService.GetLastTreeAsync(),
                Books = await this.booksService.GetLastTreeAsync(),
                Video = await this.videosService.GetMostLikedAsync(),
                Downloads = await this.downloadsService.GetLastThreeMost()
            };

            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

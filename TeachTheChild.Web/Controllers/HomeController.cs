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

        public HomeController(
            IArticlesService articlesService,
            IBooksService booksService,
            IVideosService videosService)
        {
            this.articlesService = articlesService;
            this.booksService = booksService;
            this.videosService = videosService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel
            {
                Articles = await this.articlesService.GetLastTreeAsync(),
                Books = await this.booksService.GetLastTreeAsync(),
                Video = await this.videosService.GetMostLikedAsync()
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

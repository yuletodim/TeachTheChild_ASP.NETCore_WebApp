namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using TeachTheChild.Services.Contracts;
    using TeachTheChild.Web.Models;

    public class HomeController : BaseController
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            var users = this.usersService.GetAll();

            return View(users);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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

namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Contracts;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}

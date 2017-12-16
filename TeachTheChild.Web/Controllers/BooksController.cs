namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Contracts;

    public class BooksController : BaseController
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add()
            => this.View();
        

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Add(Book model )
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View(model);
        //    }

        //    await this.booksService.AddBook(model);

        //    return this.RedirectToAction(nameof(HomeController.Index), "Home");
        //}
    }
}

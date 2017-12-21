namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Models.Books;

    public class BooksController : BaseController
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var books = await this.booksService.GetPortionAsync(page, WebConstants.BooksPageSize);
            var pagesCount = (int)Math.Ceiling(await this.booksService.GetTotalCountAsync() / (double)WebConstants.BooksPageSize);

            var data = new BooksPagingViewModel
            {
                Books = books,
                CurrentPage = page,
                PagesCount = pagesCount
            };

            return View(data);
        }

        public async Task<IActionResult> Details(int id)
               => this.View(await this.booksService.GetByIdAsync(id));
    }
}

namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Models.Books;

    public class BooksController : BaseController
    {
        private readonly IBooksService booksService;
        private readonly UserManager<User> userManager;

        public BooksController(IBooksService booksService, UserManager<User> userManager)
        {
            this.booksService = booksService;
            this.userManager = userManager;
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

        public async Task<IActionResult> LikeBookAjax(int id, bool likeBook)
        {
            var userId = this.userManager.GetUserId(this.User);

            var result = await this.booksService.AddLikeAsync(userId, id, likeBook);
            var likes = await this.booksService.GetLikesByIdAsync(id);
            var dislikes = await this.booksService.GetDislikesByIdAsync(id);

            return this.Json(new { success = result, likes = likes, dislikes = dislikes });
        }
    }
}

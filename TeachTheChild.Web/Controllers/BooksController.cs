namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Models;
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

        [HttpPost]
        public async Task<IActionResult> LikeBookAjax([FromBody]LikeFormBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new { success = false });
            }

            var userId = this.userManager.GetUserId(this.User);

            var result = await this.booksService.AddLikeAsync(userId, model.Id, model.IsLike);
            var likes = await this.booksService.GetLikesByIdAsync(model.Id);
            var dislikes = await this.booksService.GetDislikesByIdAsync(model.Id);

            return this.Json(new { success = result, likes = likes, dislikes = dislikes });
        }

        public async Task<IActionResult> AddCommentAjax(CommentFormBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new { success = false });
            }

            var userId = this.userManager.GetUserId(this.User);
            var result = await this.booksService.AddCommentAsync(userId, model.Id, model.Content, model.CommentId);

            return this.Json(new { success = result });
        }
    }
}

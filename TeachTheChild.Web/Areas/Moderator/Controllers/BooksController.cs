namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models;
    using TeachTheChild.Services.Moderator.Models.Books;
    using TeachTheChild.Web.Models;

    public class BooksController : BaseModeratorControler
    {
        private readonly IBooksModeratorService booksService;
        private readonly UserManager<User> userManager;

        public BooksController(IBooksModeratorService booksService, UserManager<User> userManager)
        {
            this.booksService = booksService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult LoadDatatableAjax(DTParameters param)
        {
            int count = 0;

            var data = this.booksService.GetFilteredPortion(
                param.Length,
                param.Start,
                param.SortColumnName,
                param.SortDirection,
                param.Search.Value,
                out count);

            var result = new DTResult<BookTableModeratorModel>
            {
                draw = param.Draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };

            return this.Json(result);
        }
    }
}

namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Moderator.Contracts;

    public class BooksController : BaseModeratorControler
    {
        private IBooksModeratorService booksService;

        public BooksController(IBooksModeratorService booksService)
        {
            this.booksService = booksService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}

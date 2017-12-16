namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TeachTheChild.Services.Moderator.Contracts;


    public class ArticlesController : BaseModeratorControler
    {
        private IArticlesModeratorService articlessService;

        public ArticlesController(IArticlesModeratorService articlessService)
        {
            this.articlessService = articlessService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}

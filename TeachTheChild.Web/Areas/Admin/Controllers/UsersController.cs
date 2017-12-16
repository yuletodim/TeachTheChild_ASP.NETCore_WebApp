namespace TeachTheChild.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TeachTheChild.Common;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Admin.Contracts;
    using TeachTheChild.Web.Areas.Admin.Models.Users;

    public class UsersController : BaseAdminController
    {
        private IUsersAdminService usersService;

        public UsersController(IUsersAdminService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var users = await this.usersService.GetAllWithPaging(page);
            var pagesCount = (int)Math.Ceiling(await this.usersService.GetTotalCountAsync() / (double)GlobalConstants.PageSize);

            var data = new UsersWithPagingViewModel
            {
                Users = users,
                CurrentPage = page,
                PagesCount = pagesCount
            };

            return View(data);
        }
    }
}

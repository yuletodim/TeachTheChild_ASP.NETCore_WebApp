namespace TeachTheChild.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Common;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Admin.Contracts;
    using TeachTheChild.Web.Areas.Admin.Models.Users;
    using System.Linq.Dynamic;
    using TeachTheChild.Web.Models;
    using TeachTheChild.Services.Admin.Models.Users;

    public class UsersController : BaseAdminController
    {
        private IUsersAdminService usersService;

        public UsersController(IUsersAdminService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            //var users = await this.usersService.GetAllWithPaging(page);
            //var pagesCount = (int)Math.Ceiling(await this.usersService.GetTotalCountAsync() / (double)GlobalConstants.PageSize);

            //var data = new UsersWithPagingViewModel
            //{
            //    Users = users,
            //    CurrentPage = page,
            //    PagesCount = pagesCount
            //};

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetDatatableDataAjax()
        {
            var data = await this.usersService.GetAllWithPaging();
            return this.Json(data);
        }

        public async Task<IActionResult> LoadDatatableAjax(DTParameters param)
        {
            var a = HttpContext.Request.Form;
            int count = 0;
            var columnSearch = param.Columns.Select(c => c.Search.Value).ToList();
            int? sortCol = null;
            string sortDir = null;
            if (param.Order != null)
            {
                sortCol = param.Order[0].Column;
                sortDir = param.Order[0].Dir.ToString();
            }


            var data = await this.usersService.GetAllWithPaging();
            var result = new DTResult<UserAdminServiceModel>
            {
                draw = param.Draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };

            return this.Json(data);

        }
    }
}

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

        public IActionResult Index(int page = 1)
        { 
            return this.View();
        }

        [HttpPost]
        public IActionResult LoadDatatableAjax(DTParameters param)
        {
            try
            {
                int count = 0;
                string sortCol = param.SortColumnName;
                string sortDir = param.SortDirection;

                var data = this.usersService.GetFilteredPortion(
                    param.Length, 
                    param.Start, 
                    sortCol, 
                    sortDir, 
                    param.Search.Value,
                    out count);

                var result = new DTResult<UserAdminServiceModel>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = data.Count(),
                    recordsTotal = count
                };

                return this.Json(result);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            

        }
    }
}

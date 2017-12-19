namespace TeachTheChild.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Admin.Contracts;
    using TeachTheChild.Services.Admin.Models.Users;
    using TeachTheChild.Web.Areas.Admin.Models.Users;
    using TeachTheChild.Web.Models;

    public class UsersController : BaseAdminController
    {
        private IUsersAdminService usersService;
        
        public UsersController(IUsersAdminService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Index([FromQuery] string role)
        { 
            return this.View(model: role);
        }

        [HttpPost]
        public IActionResult LoadDatatableAjax(DTParameters param, [FromQuery] string role)
        {
            int count = 0;
        
            var data = this.usersService.GetFilteredPortion(
                role,
                param.Length, 
                param.Start,
                param.SortColumnName,
                param.SortDirection, 
                param.Search.Value,
                out count);

            var result = new DTResult<UserAdminServiceModel>
            {
                draw = param.Draw,
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };

            return this.Json(result);
        }

        public async Task<IActionResult> GetUserAjax([FromQuery]string id)
        {
            var user = await this.usersService.GetByIdAsync(id);

            return this.PartialView("_UserDetailsPartial", user);
        }

        public async Task<IActionResult> AddUserToRoleGetAsync([FromQuery]string userId)
        {
            var roles = await this.usersService.GetRolesAsync();
            var selectListRoles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            });

            var model = new AddUserToRoleViewModel
            {
                UserId = userId,
                Roles = selectListRoles
            };

            return this.PartialView("_AddUserToRolePartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleBindingModel model)
        {
            var result = await this.usersService.AddUserToRoleAsync(model.UserId, model.Role);
           
            return this.Json(new { success = result });
        }
    }
}

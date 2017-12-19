namespace TeachTheChild.Web.Areas.Admin.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class AddUserToRoleViewModel
    {
        public string UserId { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}

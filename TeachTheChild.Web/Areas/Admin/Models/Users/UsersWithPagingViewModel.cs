using System.Collections.Generic;
using TeachTheChild.Services.Admin.Models.Users;

namespace TeachTheChild.Web.Areas.Admin.Models.Users
{
    public class UsersWithPagingViewModel
    {
        public IEnumerable<UserAdminServiceModel> Users { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousePage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int PagesCount { get; set; }

        public int NextPage => this.CurrentPage == this.PagesCount ? this.PagesCount : this.CurrentPage + 1;
    }
}

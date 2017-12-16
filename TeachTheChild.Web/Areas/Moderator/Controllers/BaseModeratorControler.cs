namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TeachTheChild.Data;
    using TeachTheChild.Web.Infrastructure.Constants;
    using TeachTheChild.Web.Infrastructure.Filters;

    [Area(WebConstants.ModeratorArea)]
    //[AuthorizeRoles(DataConstants.AdminRole, DataConstants.ModeratorRole)]
    public class BaseModeratorControler : Controller
    {
    }
}

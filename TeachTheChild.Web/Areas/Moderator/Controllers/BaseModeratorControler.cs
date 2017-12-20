namespace TeachTheChild.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TeachTheChild.Data;
    using TeachTheChild.Web.Infrastructure.Constants;

    [Area(WebConstants.ModeratorArea)]
    [Authorize(Roles = DataConstants.AdminRole + ", "  + DataConstants.ModeratorRole)]
    public abstract class BaseModeratorControler : Controller
    {
    }
}

namespace TeachTheChild.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TeachTheChild.Data;
    using TeachTheChild.Web.Infrastructure.Constants;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = DataConstants.AdminRole)]
    public abstract class BaseAdminController : Controller
    {
    }
}

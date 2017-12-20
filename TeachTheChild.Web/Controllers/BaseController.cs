namespace TeachTheChild.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TeachTheChild.Web.Infrastructure.Filters;

    [Authorize]
    [SetLanguage]
    public abstract class BaseController : Controller
    {
    }
}

namespace TeachTheChild.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Globalization;
    using System.Threading;
    using TeachTheChild.Web.Infrastructure.Constants;

    public class SetLanguageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var language = context.HttpContext.Request.Cookies["langCookie"];
            if (language == null)
            {
                language = WebConstants.DefaultEnglishCulture;
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            base.OnActionExecuting(context);
        }
    }
}

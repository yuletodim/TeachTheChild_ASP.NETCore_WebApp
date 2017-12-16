namespace TeachTheChild.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Authorization;

    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) 
            : base()
        {
            Roles = string.Join(", ", Roles);
        }
    }
}

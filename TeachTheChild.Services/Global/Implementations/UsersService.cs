namespace TeachTheChild.Services.Global.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Global.Contracts;

    public class UsersService : IUsersService
    {
        private TeachTheChildDbContext dbContext;

        public UsersService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task EditUserDetailsAsync(string userId, string name, int countryId, int languageId)
        {
            var user = await this.dbContext.Users.FindAsync(userId);
            user.Name = name;
            user.CountryId = countryId;
            user.LanguageId = languageId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> GetUserLanguageIdAsync(string id)
            => await this.dbContext
                .Users
                .Where(u => u.Id == id)
                .Select(u => u.LanguageId)
                .FirstOrDefaultAsync();
    }
}

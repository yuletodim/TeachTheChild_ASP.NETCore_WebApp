namespace TeachTheChild.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Contracts;
    using TeachTheChild.Services.Models;

    public class LanguagesService : ILanguagesService
    {
        private readonly TeachTheChildDbContext dbContext;

        public LanguagesService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<LanguageShortModel>> GetAllAsync()
            => await this.dbContext
                .Languages
                .ProjectTo<LanguageShortModel>()
                .ToListAsync();

        public async Task<int> GetDefaultLanguageId()
            => await this.dbContext
                .Languages
                .Where(l => l.Name == DataConstants.EnglishLanguage)
                .Select(l => l.Id)
                .FirstOrDefaultAsync();

        public async Task<int> GetLanguageId(string name)
            => await this.dbContext
                .Languages
                .Where(l => l.Name == name)
                .Select(l => l.Id)
                .FirstOrDefaultAsync();
    }
}

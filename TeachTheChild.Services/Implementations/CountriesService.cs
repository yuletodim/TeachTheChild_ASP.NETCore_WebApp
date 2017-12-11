namespace TeachTheChild.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Contracts;
    using TeachTheChild.Services.Models;

    public class CountriesService : ICountriesService
    {
        private readonly TeachTheChildDbContext dbContext;

        public CountriesService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CountryShortModel>> GetAllAsync()
            => await this.dbContext
                .Countries
                .ProjectTo<CountryShortModel>()
                .ToListAsync();
    }
}

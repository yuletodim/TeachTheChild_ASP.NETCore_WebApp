namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Global.Models;

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

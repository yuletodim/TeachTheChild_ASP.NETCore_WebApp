namespace TeachTheChild.Data
{
    using Microsoft.AspNetCore.Identity;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using TeachTheChild.Data.Models;

    public class DbInitializer : IDbInitializer
    {
        private const string CountriesApiUrl = "https://restcountries.eu/rest/v2/all";

        private readonly TeachTheChildDbContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbInitializer(
            TeachTheChildDbContext dbContext,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task Initialize()
        {
            this.dbContext.Database.EnsureCreated();

            if (!this.dbContext.Roles.Any())
            {
                await this.SeedRolesAsync();
            }

            if (!this.dbContext.Countries.Any())
            {
                await this.SeedCountries();
            }

        }

        private async Task SeedRolesAsync()
        {
            var roles = new string[] 
            {
                DataConstants.AdminRole,
                DataConstants.ModeratorRole
            };

            foreach (var role in roles)
            {
                var roleExists = await this.roleManager.RoleExistsAsync(role);
                if(!roleExists)
                {
                    await this.roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private async Task SeedCountries()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(CountriesApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var countries = JsonConvert.DeserializeObject<IEnumerable<CountryDTO>>(responseContent);

                foreach (var country in countries)
                {
                    await this.dbContext.AddAsync(
                        new Country
                        {
                            Name = country.name,
                            Flag = country.alpha2Code,
                            FlagUrl = country.flag
                        });
                }

                await this.dbContext.SaveChangesAsync();
            }
        }
    }

    public class CountryDTO
    {
        public string name { get; set; }

        public string alpha2Code { get; set; }

        public string flag { get; set; }
    }

}

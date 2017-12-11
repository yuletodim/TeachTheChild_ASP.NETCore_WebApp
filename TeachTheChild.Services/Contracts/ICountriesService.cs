namespace TeachTheChild.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Models;

    public interface ICountriesService
    {
        Task<IEnumerable<CountryShortModel>> GetAllAsync();
    }
}

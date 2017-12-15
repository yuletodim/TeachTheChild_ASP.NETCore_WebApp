namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models;

    public interface ICountriesService
    {
        Task<IEnumerable<CountryShortModel>> GetAllAsync();
    }
}

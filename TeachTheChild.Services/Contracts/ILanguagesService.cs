namespace TeachTheChild.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Models;

    public interface ILanguagesService
    {
        Task<IEnumerable<LanguageShortModel>> GetAllAsync();

        Task<int> GetDefaultLanguageId();

        Task<int> GetLanguageId(string name);
    }
}

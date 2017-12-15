namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models;

    public interface ILanguagesService
    {
        Task<IEnumerable<LanguageShortModel>> GetAllAsync();

        Task<int> GetDefaultLanguageId();

        Task<int> GetLanguageId(string name);
    }
}

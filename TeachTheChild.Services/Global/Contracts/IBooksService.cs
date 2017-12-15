namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models.Books;

    public interface IBooksService
    {
        Task<IEnumerable<BookShortModel>> GetLastTree();
    }
}

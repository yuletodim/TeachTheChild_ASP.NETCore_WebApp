namespace TeachTheChild.Services.Contracts
{
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Data.Models.Materials;

    public interface IBooksService
    {
        Task<bool> AddBook(Book book);
    }
}

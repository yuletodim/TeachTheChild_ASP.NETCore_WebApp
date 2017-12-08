namespace TeachTheChild.Services.Contracts
{
    using System.Threading.Tasks;
    using TeachTheChild.Data.Models;

    public interface IBooksService
    {
        Task<bool> AddBook(Book book);
    }
}

namespace TeachTheChild.Services.Global.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TeachTheChild.Services.Global.Models.Books;

    public interface IBooksService
    {
        Task<IEnumerable<BookShortModel>> GetLastTreeAsync();

        Task<IEnumerable<BookShortModel>> GetPortionAsync(int page, int pageSize);

        Task<int> GetTotalCountAsync();

        Task<BookDetailsModel> GetByIdAsync(int id);

        Task<bool> AddLikeAsync(string userId, int bookId, bool likeValue);

        Task<bool> AddCommentAsync(string userId, int bookId, string content, int? baseCommentId = null);

        Task<bool> AddCommentLikeAsync(string userId, int bookCommentId, bool likeValue);

        Task<int> GetLikesByIdAsync(int id);

        Task<int> GetDislikesByIdAsync(int id);
    }
}

namespace TeachTheChild.Services.Moderator.Implementations
{
    using System.Threading.Tasks;

    using TeachTheChild.Data;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Data.Models.Books;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Moderator.Contracts;

    public class BooksModeratorService : IBooksModeratorService
    {
        private TeachTheChildDbContext dbContext;

        public BooksModeratorService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddBook(Book book)
        {
            try
            {
                await this.dbContext.AddAsync(book);
                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}

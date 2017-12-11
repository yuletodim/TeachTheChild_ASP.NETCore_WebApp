namespace TeachTheChild.Services.Implementations
{
    using System.Threading.Tasks;

    using TeachTheChild.Data;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Data.Models.Materials;
    using TeachTheChild.Services.Contracts;
    
    public class BooksService : IBooksService
    {
        private TeachTheChildDbContext dbContext;

        public BooksService(TeachTheChildDbContext dbContext)
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

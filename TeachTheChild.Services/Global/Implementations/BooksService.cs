namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TeachTheChild.Data;
    using TeachTheChild.Data.Models.Books;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Global.Models.Books;

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

        public async Task<IEnumerable<BookShortModel>> GetLastTreeAsync()
            => await this.dbContext
                .Books
                .OrderByDescending(a => a.CreatedOn)
                .Skip(0)
                .Take(3)
                .ProjectTo<BookShortModel>()
                .ToListAsync();
    }
}

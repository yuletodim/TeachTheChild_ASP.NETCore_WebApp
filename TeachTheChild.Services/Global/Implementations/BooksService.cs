namespace TeachTheChild.Services.Global.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Global.Models.Books;

    public class BooksService : IBooksService
    {
        private TeachTheChildDbContext dbContext;

        public BooksService(TeachTheChildDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BookDetailsModel> GetByIdAsync(int id)
            => await this.dbContext
                .Books
                .Where(a => a.Id == id)
                .ProjectTo<BookDetailsModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookShortModel>> GetLastTreeAsync()
            => await this.dbContext
                .Books
                .OrderByDescending(a => a.CreatedOn)
                .Skip(0)
                .Take(3)
                .ProjectTo<BookShortModel>()
                .ToListAsync();

        public async Task<IEnumerable<BookShortModel>> GetPortionAsync(int page, int pageSize)
            => await this.dbContext
                .Books
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BookShortModel>()
                .ToListAsync();

        public async Task<int> GetTotalCountAsync()
            => await this.dbContext
                .Books
                .CountAsync();
    }
}

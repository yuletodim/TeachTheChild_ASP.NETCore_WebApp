namespace TeachTheChild.Services.Moderator.Implementations
{
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Common.Extensions;
    using TeachTheChild.Data;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Data.Models.Books;
    using TeachTheChild.Services.Global.Contracts;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models;

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

        public IEnumerable<BookTableModeratorModel> GetFilteredPortion(
            int length, 
            int start, 
            string sortCol, 
            string sortDir, 
            string search, 
            out int count)
        {
            var books = this.dbContext
                .Books
                .Where(b => search == null
                || b.Title.ToLower().Contains(search.ToLower())
                || b.User.Name.ToLower().Contains(search.ToLower())
                || b.Author.ToLower().Contains(search.ToLower())
                || b.CreatedOn.ToString().ToLower().Contains(search.ToLower()));

            count = books.Count();

            var booksModel = books
                    .OrderByField(sortCol, sortDir)
                    .Skip(start)
                    .Take(length)
                    .ProjectTo<BookTableModeratorModel>()
                    .ToList();

            return booksModel;
        }
    }
}

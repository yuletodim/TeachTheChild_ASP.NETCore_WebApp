﻿namespace TeachTheChild.Services.Moderator.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TeachTheChild.Common.Extensions;
    using TeachTheChild.Data;
    using TeachTheChild.Data.Models.Books;
    using TeachTheChild.Services.Moderator.Contracts;
    using TeachTheChild.Services.Moderator.Models.Books;

    public class BooksModeratorService : IBooksModeratorService
    {
        private readonly TeachTheChildDbContext dbContext;
        private readonly IMapper mapper;

        public BooksModeratorService(TeachTheChildDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
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
                    .ProjectTo<BookTableModeratorModel>()
                    .OrderByField(sortCol, sortDir)
                    .Skip(start)
                    .Take(length)                 
                    .ToList();

            return booksModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await this.dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            this.dbContext.Remove(book);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<int> AddAsync(BookFormModel bookModel)
        {
            var book = this.mapper.Map<Book>(bookModel);

            await this.dbContext.AddAsync(book);
            await this.dbContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task<string> GetPictureUrlByIdAsync(int id)
            => await this.dbContext
                .Books
                .Where(b => b.Id == id)
                .Select(b => b.PictureUrl)
                .FirstOrDefaultAsync();

        public async Task<BookFormModel> GetByIdAsync(int id)
            => await this.dbContext
                .Books
                .Where(b => b.Id == id)
                .ProjectTo<BookFormModel>()
                .FirstOrDefaultAsync();

        public async Task<bool> EditAsync(BookFormModel bookModel)
        {
            var book = await this.dbContext.Books.FindAsync(bookModel.Id);
            if(book == null)
            {
                return false;
            }

            book.Title = bookModel.Title;
            book.Author = bookModel.Author;
            book.Publisher = bookModel.Publisher;
            book.Descritpion = bookModel.Descritpion;
            if (bookModel.PictureUrl != null)
            {
                book.PictureUrl = bookModel.PictureUrl;
            }
            
            await this.dbContext.SaveChangesAsync();

            return true;
        }
    }
}

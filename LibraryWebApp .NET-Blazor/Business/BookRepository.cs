using AutoMapper;
using Business.IRepository;
using Data;
using Data.DataContext;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;

        public BookRepository(LibraryDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var bookToDelete = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (bookToDelete != null)
            {
                _db.Books.Remove(bookToDelete);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(await _db.Books
                                    .Include(b => b.Publisher)
                                    .Include(b => b.Authors)
                                    .Include(b => b.Categories)
                                    .Include(b => b.CopiesCurrentlyBorrowed).ToListAsync()); ;
        }

        public async Task<BookDto> GetByIdAsync(Guid id)
        {
            var book = await _db.Books.Include(b => b.Publisher)
                                    .Include(b => b.Authors)
                                    .Include(b => b.Categories)
                                    .Include(b => b.CopiesCurrentlyBorrowed).FirstOrDefaultAsync(b => b.Id == id);
            if (book != null)
            {
                return _mapper.Map<Book, BookDto>(book);
            }
            return new BookDto();
        }

        public async Task<BookDto> InsertAsync(BookDto dto)
        {
            var bookToInsert = _mapper.Map<BookDto, Book>(dto);
            var insertedBook = await _db.Books.AddAsync(bookToInsert);
            await _db.SaveChangesAsync();
            return _mapper.Map<Book, BookDto>(insertedBook.Entity);
        }

        public async Task<BookDto> UpdateAsync(BookDto dto)
        {
            var bookToUpdate = await _db.Books.FirstOrDefaultAsync(b => b.Id == dto.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = dto.Title;
                bookToUpdate.Isbn = dto.Isbn;
                bookToUpdate.Description = dto.Description;
                bookToUpdate.CopiesInLibrary = dto.CopiesInLibrary;
                bookToUpdate.NeedsPremiumMembershipToBorrow = dto.NeedsPremiumMembershipToBorrow;
                bookToUpdate.Language = _mapper.Map<LanguageDto, Language>(dto.Language);
                bookToUpdate.Publisher = _mapper.Map<PublisherDto, Publisher>(dto.Publisher);
                bookToUpdate.Authors = _mapper.Map<IEnumerable<AuthorDto>, IEnumerable<Author>>(dto.Authors);
                bookToUpdate.Categories = _mapper.Map<IEnumerable<CategoryDto>, IEnumerable<Category>>(dto.Categories);
                bookToUpdate.CopiesCurrentlyBorrowed = _mapper.Map<IEnumerable<BorrowDetailsDto>, IEnumerable<BorrowDetails>>(dto.CopiesCurrentlyBorrowed);

                var updatedBook = _db.Books.Update(bookToUpdate);
                await _db.SaveChangesAsync();
                return _mapper.Map<Book, BookDto>(updatedBook.Entity);
            }
            return new BookDto();
        }
    }
}

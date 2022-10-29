using AutoMapper;
using Business.IRepository;
using Data;
using Data.DataContext;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;

        public AuthorRepository(LibraryDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var authorToDelete = await _db.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (authorToDelete != null)
            {
                _db.Authors.Remove(authorToDelete);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<AuthorDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDto>>(await _db.Authors.ToListAsync());
        }

        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            var author = await _db.Authors.Include(a => a.CountryOfOrigin).FirstOrDefaultAsync(a => a.Id == id);
            if (author != null)
            {
                return _mapper.Map<Author, AuthorDto>(author);
            }
            return new AuthorDto();
        }

        public async Task<AuthorDto> InsertAsync(AuthorDto dto)
        {
            var newAuthor = _mapper.Map<AuthorDto, Author>(dto);
            var insertedAuthor = await _db.Authors.AddAsync(newAuthor);
            await _db.SaveChangesAsync();
            return _mapper.Map<Author, AuthorDto>(insertedAuthor.Entity);
        }

        public async Task<AuthorDto> UpdateAsync(AuthorDto dto)
        {
            var authorToUpdate = await _db.Authors.Include(a => a.CountryOfOrigin).FirstOrDefaultAsync(a => a.Id == dto.Id);
            if (authorToUpdate != null)
            {
                authorToUpdate.Firstname = dto.Firstname;
                authorToUpdate.Lastname = dto.Lastname;
                authorToUpdate.AuthorImageUrl = dto.ImageUrl;
                authorToUpdate.MiniBio = dto.MiniBio;
                authorToUpdate.Categories = _mapper.Map<IEnumerable<CategoryDto>, IEnumerable<Category>>(dto.Categories);
                authorToUpdate.BooksAuthored = _mapper.Map<IEnumerable<BookDto>, IEnumerable<Book>>(dto.BooksAuthored);

                var updatedAuthor = _db.Authors.Update(authorToUpdate);
                await _db.SaveChangesAsync();
                return _mapper.Map<Author, AuthorDto>(updatedAuthor.Entity);
            }
            return new AuthorDto();
        }
    }
}

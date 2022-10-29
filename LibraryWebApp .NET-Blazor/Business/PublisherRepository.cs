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
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;

        public PublisherRepository(LibraryDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var publisherToDelete = await _db.Publishers.FirstOrDefaultAsync(p => p.Id == id);
            if (publisherToDelete != null)
            {
                _db.Publishers.Remove(publisherToDelete);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<PublisherDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherDto>>(await _db.Publishers.ToListAsync());
        }

        public async Task<PublisherDto> GetByIdAsync(Guid id)
        {
            var publisher = await _db.Publishers.Include(p => p.BooksPublished).FirstOrDefaultAsync(p => p.Id == id);
            if (publisher != null)
            {
                return _mapper.Map<Publisher, PublisherDto>(publisher);
            }
            return new PublisherDto();
        }

        public async Task<PublisherDto> InsertAsync(PublisherDto dto)
        {
            var publisherToInsert = _mapper.Map<PublisherDto, Publisher>(dto);
            var insertedPublisher = await _db.Publishers.AddAsync(publisherToInsert);
            await _db.SaveChangesAsync();
            return _mapper.Map<Publisher, PublisherDto>(insertedPublisher.Entity);
        }

        public async Task<PublisherDto> UpdateAsync(PublisherDto dto)
        {
            var publisherToUpdate = await _db.Publishers.Include(p => p.BooksPublished).FirstOrDefaultAsync(p => p.Id == dto.Id);
            if (publisherToUpdate != null)
            {
                publisherToUpdate.PublisherName = dto.PublisherName;
                publisherToUpdate.BooksPublished = _mapper.Map<IEnumerable<BookDto>, IEnumerable<Book>>(dto.BooksPublished);
                var updatedPublisher = _db.Publishers.Update(publisherToUpdate);
                await _db.SaveChangesAsync();
                return _mapper.Map<Publisher, PublisherDto>(updatedPublisher.Entity);
            }
            return new PublisherDto();
        }
    }
}

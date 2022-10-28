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
    public class CountryRepository : ICountryRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;

        public CountryRepository(LibraryDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var country = await _db.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country != null)
            {
                _db.Countries.Remove(country);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            return  _mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(await _db.Countries!.ToListAsync());
        }

        public async Task<CountryDto> GetByIdAsync(Guid id)
        {
            var country = await _db.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country != null)
            {
                return _mapper.Map<Country, CountryDto>(country);
            }
            return new CountryDto();
        }

        public async Task<CountryDto> InsertAsync(CountryDto dto)
        {
            var country = _mapper.Map<CountryDto, Country>(dto);
            var insertedCountry = await _db.Countries.AddAsync(country);
            await _db.SaveChangesAsync();
            return _mapper.Map<Country, CountryDto>(insertedCountry.Entity);
        }

        public async Task<CountryDto> UpdateAsync(CountryDto dto)
        {
            var country = await _db.Countries.FirstOrDefaultAsync(c => c.Id == dto.Id);
            if (country != null)
            {
                country.CountryName = dto.CountryName;
                var updatedCountry = _db.Countries.Update(country);
                await _db.SaveChangesAsync();
                return _mapper.Map<Country, CountryDto>(updatedCountry.Entity);
            }
            return new CountryDto();
        }
    }
}

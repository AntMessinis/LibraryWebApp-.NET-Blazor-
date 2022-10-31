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
    public class CityRepository : ICityRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;

        public CityRepository(LibraryDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var city = await _db.Cities.FirstOrDefaultAsync(c => c.Id == id);
            if (city != null)
            {
                _db.Cities.Remove(city);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(await _db.Cities.Include(c => c.Country).ToListAsync());
        }

        public async Task<CityDto> GetByIdAsync(int id)
        {
            var city = await _db.Cities.Include(c => c.Country).FirstOrDefaultAsync(c => c.Id == id);
            if (city != null)
            {
                return _mapper.Map<City, CityDto>(city);
            }
            return new CityDto();
        }

        public async Task<CityDto> InsertAsync(CityDto dto)
        {
            var newCity = _mapper.Map<CityDto, City>(dto);
            var insertedCity = await _db.Cities.AddAsync(newCity);
            await _db.SaveChangesAsync();
            return _mapper.Map<City, CityDto>(insertedCity.Entity);
        }

        public async Task<CityDto> UpdateAsync(CityDto dto)
        {
            var cityToUpdate = await _db.Cities.Include(c => c.Country).FirstOrDefaultAsync(c => c.Id == dto.Id);
            if (cityToUpdate != null)
            {
                cityToUpdate.CityName = dto.CityName;
                cityToUpdate.Country = _mapper.Map<CountryDto, Country>(dto.Country);
                cityToUpdate.CountryId = cityToUpdate.Country.Id;
                var updatedCity = _db.Cities.Update(cityToUpdate);
                await _db.SaveChangesAsync();
                return _mapper.Map<City, CityDto>(updatedCity.Entity);
            }
            return new CityDto();
        }
    }
}

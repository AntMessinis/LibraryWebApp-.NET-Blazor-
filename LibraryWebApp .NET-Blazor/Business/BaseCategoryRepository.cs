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
    public class BaseCategoryRepository : IBaseCategoryRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;

        public BaseCategoryRepository(LibraryDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var baseCatToDelete = await _db.BasicCategories.FirstOrDefaultAsync(b => b.Id == id);
            if (baseCatToDelete != null)
            {
                _db.BasicCategories.Remove(baseCatToDelete);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<BaseCategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<BaseCategory>, IEnumerable<BaseCategoryDto>>(await _db.BasicCategories.AsNoTrackingWithIdentityResolution().ToListAsync());
        }

        public async Task<BaseCategoryDto> GetByIdAsync(int id)
        {
            var baseCat = await _db.BasicCategories.FirstOrDefaultAsync(b => b.Id == id);
            if (baseCat != null)
            {
                return _mapper.Map<BaseCategory, BaseCategoryDto>(baseCat);
            }
            return new BaseCategoryDto();
        }

        public async Task<BaseCategoryDto> InsertAsync(BaseCategoryDto dto)
        {
            var newBaseCat = _mapper.Map<BaseCategoryDto, BaseCategory>(dto);
            var insertedBaseCat = _db.BasicCategories.Add(newBaseCat);
            await _db.SaveChangesAsync();
            return _mapper.Map<BaseCategory, BaseCategoryDto>(insertedBaseCat.Entity);
        }

        public async Task<BaseCategoryDto> UpdateAsync(BaseCategoryDto dto)
        {
            var baseCatToUpdate = await _db.BasicCategories.FirstOrDefaultAsync(b => b.Id == dto.Id);
            if (baseCatToUpdate != null)
            {
                baseCatToUpdate.BaseCategoryName = dto.BaseCategoryName;
                var updatedBaseCat = _db.BasicCategories.Update(baseCatToUpdate);
                await _db.SaveChangesAsync();
                return _mapper.Map<BaseCategory, BaseCategoryDto>(updatedBaseCat.Entity);
            }
            return new BaseCategoryDto();
        }
    }
}

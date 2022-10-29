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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(LibraryDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var catToDelete = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (catToDelete != null)
            {
                _db.Categories.Remove(catToDelete);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(await _db.Categories.ToListAsync());
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                return _mapper.Map<Category, CategoryDto>(category);
            }
            return new CategoryDto();
        }

        public async Task<CategoryDto> InsertAsync(CategoryDto dto)
        {
            var catToInsert = _mapper.Map<CategoryDto, Category>(dto);
            var insertedCat = await _db.Categories.AddAsync(catToInsert);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDto>(insertedCat.Entity);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto dto)
        {
            var catToUpdate = await _db.Categories.FirstOrDefaultAsync(c => c.Id == dto.Id);
            if (catToUpdate != null)
            {
                catToUpdate.CategoryName = dto.CategoryName;
                catToUpdate.BasicCategory = _mapper.Map<BaseCategoryDto, BaseCategory>(dto.BasicCategory);
                var updatedCat = _db.Categories.Update(catToUpdate);
                await _db.SaveChangesAsync();

                return _mapper.Map<Category, CategoryDto>(updatedCat.Entity);
            }
            return new CategoryDto();
        }
    }
}

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
    public class LanguageRepository : ILanguageRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;

        public LanguageRepository(LibraryDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var langToDelete = await _db.Languages.FirstOrDefaultAsync(l => l.Id == id);
            if (langToDelete != null)
            {
                _db.Languages.Remove(langToDelete);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<LanguageDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Language>, IEnumerable<LanguageDto>>(await _db.Languages.ToListAsync());
        }

        public async Task<LanguageDto> GetByIdAsync(int id)
        {
            var lang = await _db.Languages.FirstOrDefaultAsync(l => l.Id == id);
            if (lang != null)
            {
                return _mapper.Map<Language, LanguageDto>(lang);
            }
            return new LanguageDto();
        }

        public async Task<LanguageDto> InsertAsync(LanguageDto dto)
        {
            var newLang = _mapper.Map<LanguageDto, Language>(dto);
            if (newLang != null)
            {
                var insertedLang = await _db.Languages.AddAsync(newLang);
                await _db.SaveChangesAsync();
                return _mapper.Map<Language, LanguageDto>(insertedLang.Entity);
            }
            return new LanguageDto();
        }

        public async Task<LanguageDto> UpdateAsync(LanguageDto dto)
        {
            var langToUpdate = await _db.Languages.FirstOrDefaultAsync(l => l.Id == dto.Id);
            if (langToUpdate != null)
            {
                langToUpdate.LanuageName = dto.LanguageName;
                var updatedLang = _db.Languages.Update(langToUpdate);
                await _db.SaveChangesAsync();
                return _mapper.Map<Language, LanguageDto>(updatedLang.Entity);
            }
            return new LanguageDto();
        }
    }
}

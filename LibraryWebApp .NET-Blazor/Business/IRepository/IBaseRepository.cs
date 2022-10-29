using Data;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRepository
{
    public interface IBaseRepository<TEntity, TDto> where TEntity: BaseEntity where TDto : BaseDto
    {
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> InsertAsync(TDto dto);
        Task<TDto> UpdateAsync(TDto dto);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<TDto>> GetAll();
    }
}

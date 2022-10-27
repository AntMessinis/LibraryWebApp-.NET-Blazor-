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
        Task<TDto> GetByIdAsync(Guid id);
        Task<TDto> InsertAsync(TDto dto);
        Task<TDto> UpdateAsync(TDto dto);
        Task<int> DeleteAsync(Guid id);
        Task<IEnumerable<TDto>> GetAll();
    }
}

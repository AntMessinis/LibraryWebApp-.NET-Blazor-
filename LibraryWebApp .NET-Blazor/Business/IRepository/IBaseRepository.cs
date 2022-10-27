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
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> InsertAsync(TDto dto);
        Task<TEntity> UpdateAsync(TDto dto);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}

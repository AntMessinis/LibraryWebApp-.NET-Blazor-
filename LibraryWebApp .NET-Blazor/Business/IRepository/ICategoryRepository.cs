using Data;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category, CategoryDto>
    {
    }
}

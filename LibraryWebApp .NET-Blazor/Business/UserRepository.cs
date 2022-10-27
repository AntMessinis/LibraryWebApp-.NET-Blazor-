using Business.IRepository;
using Data;
using Data.DataContext;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _db;

        public UserRepository(LibraryDbContext db)
        {
            _db = db;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> InsertAsync(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(UserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

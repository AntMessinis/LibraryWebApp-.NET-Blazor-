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
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;

        public UserRepository(LibraryDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UserDto> InsertAsync(UserDto dto)
        {
            var user = _mapper.Map<UserDto, User>(dto);
            user.UserMemberhipDetails.MembershipCreationDate = DateTime.UtcNow;
            var insertedUser = await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return _mapper.Map<User, UserDto>(insertedUser.Entity);    
            
        }

        public async Task<int> DeleteAsync(int id)
        {
            var user = _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _db.Remove(user);
                return await _db.SaveChangesAsync();
            }
            
            return 0;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(await _db.Users!.ToListAsync());
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _db.Users.Include(u => u.UserMemberhipDetails)
                                    .Include(u => u.BooksCurrentlyBorrowed)
                                    .FirstOrDefaultAsync(u => u.Id==id);
            if (user != null)
            {
                return _mapper.Map<User, UserDto>(user);
            }
            return new UserDto();
        }

        

        public async Task<UserDto> UpdateAsync(UserDto dto)
        {
            var userToUpdate = await _db.Users.FirstOrDefaultAsync(u => u.Id == dto.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Email = dto.Email;
                userToUpdate.Password = dto.Password;
                userToUpdate.UserMemberhipDetails = _mapper.Map<MembershipDetailsDto,MembershipDetails>(dto.UserMemberhipDetails);
                userToUpdate.UserImageUrl = dto.UserImageUrl;
                var updatedUser = _db.Users.Update(userToUpdate);
                await _db.SaveChangesAsync();
                return _mapper.Map<User, UserDto>(updatedUser.Entity);
            }
            return new UserDto();
        }
    }
}

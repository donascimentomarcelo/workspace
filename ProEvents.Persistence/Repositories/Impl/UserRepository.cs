using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain.Identity;

namespace ProEvents.Persistence.Repositories.Impl
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await context.Users.SingleOrDefaultAsync(x => x.UserName == username.ToLower());
        }
    }
}
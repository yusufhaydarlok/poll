using Microsoft.EntityFrameworkCore;
using poll_core.Models;
using poll_core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetUsersWithRole()
        {
            return await _context.Users.Include(x => x.Role).ToListAsync();
        }
    }
}

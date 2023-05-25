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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Role> GetSingleRoleByIdWithUsersAsync(int roleId)
        {
            return await _context.Roles.Include(x => x.Users).Where(x => x.Id == roleId).SingleOrDefaultAsync();
        }
    }
}

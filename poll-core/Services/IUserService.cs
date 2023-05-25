using poll_core.DTOs;
using poll_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_core.Services
{
    public interface IUserService : IService<User>
    {
        Task<CustomResponseDto<List<UserWithRoleDto>>> GetUsersWithRole();
    }
}

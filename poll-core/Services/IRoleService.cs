using poll_core.DTOs;
using poll_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_core.Services
{
    public interface IRoleService : IService<Role>
    {
        Task<CustomResponseDto<RoleWithUsersDto>> GetSingleRoleByIdWithUsersAsync(int roleId);
    }
}

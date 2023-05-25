using AutoMapper;
using poll_core.DTOs;
using poll_core.Models;
using poll_core.Repositories;
using poll_core.Services;
using poll_core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_service.Services
{
    public class RoleService : Service<Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IGenericRepository<Role> repository, IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository roleRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<CustomResponseDto<RoleWithUsersDto>> GetSingleRoleByIdWithUsersAsync(int roleId)
        {
            var role = await _roleRepository.GetSingleRoleByIdWithUsersAsync(roleId);
            var roleDto = _mapper.Map<RoleWithUsersDto>(role);
            return CustomResponseDto<RoleWithUsersDto>.Success(200, roleDto);
        }
    }
}

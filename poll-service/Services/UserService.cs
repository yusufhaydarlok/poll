using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using poll_core.DTOs;
using poll_core.Models;
using poll_core.Repositories;
using poll_core.Services;
using poll_core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace poll_service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CustomResponseDto<List<UserWithRoleDto>>> GetUsersWithRole()
        {
            var users = await _userRepository.GetUsersWithRole();
            var usersDto = _mapper.Map<List<UserWithRoleDto>>(users);
            return CustomResponseDto<List<UserWithRoleDto>>.Success(200, usersDto);
        }

        public Task<User> AddUserAsync(UserDto entity)
        {
            CreatePasswordHash(entity.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = _mapper.Map<User>(entity);
            user.Username = entity.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return base.AddAsync(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public string GetMyId()
        {
            var result = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");
            }

            return result;
        }

        public async Task<AdminUserDto> AddAdminUserAsync(AdminUserDto entity)
        {
            CreatePasswordHash(entity.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = _mapper.Map<User>(entity);
            user.Username = entity.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return _mapper.Map<AdminUserDto>(await base.AddAsync(user));
        }
    }
}

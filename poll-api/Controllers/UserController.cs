using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poll_api.Filters;
using poll_core.DTOs;
using poll_core.Models;
using poll_core.Services;
using System.Security.Cryptography;

namespace poll_api.Controllers
{
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("[action]"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsersWithRole()
        {
            return CreateActionResult(await _userService.GetUsersWithRole());
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, usersDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var usersDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, usersDto));
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(AdminUserDto adminUserDto)
        {
            var user = await _userService.AddAdminUserAsync(adminUserDto);
            var usersDto = _mapper.Map<AdminUserDto>(user);
            return CreateActionResult(CustomResponseDto<AdminUserDto>.Success(201, usersDto));
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UserUpdateDto userDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(userDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            await _userService.RemoveAsync(user);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}

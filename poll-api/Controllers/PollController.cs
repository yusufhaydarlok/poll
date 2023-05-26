using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poll_core.DTOs;
using poll_core.Services;

namespace poll_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IPollService _userService;
        private readonly IMapper _mapper;

        public PollController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet, Authorize("Id")]
        public async Task<IActionResult> All()
        {
            var polls = await _pollservice.GetAllAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, usersDto));
        }
    }
}

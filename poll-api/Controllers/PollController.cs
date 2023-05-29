using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poll_api.Filters;
using poll_core.DTOs;
using poll_core.DTOs.Poll;
using poll_core.DTOs.Poll;
using poll_core.Models;
using poll_core.Services;
using System.Data;

namespace poll_api.Controllers
{
    public class PollController : CustomBaseController
    {
        private readonly IPollService _pollService;
        private readonly IMapper _mapper;

        public PollController(IPollService pollService, IMapper mapper)
        {
            _pollService = pollService;
            _mapper = mapper;
        }

        [HttpGet, Authorize(Roles = "Admin"), Authorize(Roles = "User")]
        public async Task<IActionResult> All()
        {
            var polls = await _pollService.GetAllAsync();
            var pollsDto = _mapper.Map<List<PollDto>>(polls.ToList());
            return CreateActionResult(CustomResponseDto<List<PollDto>>.Success(200, pollsDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Poll>))]
        [HttpGet("{id}"), Authorize(Roles = "Admin"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetById(int id)
        {
            var poll = await _pollService.GetByIdAsync(id);
            var pollsDto = _mapper.Map<PollDto>(poll);
            return CreateActionResult(CustomResponseDto<PollDto>.Success(200, pollsDto));
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(PollDto pollDto)
        {
            var don = _mapper.Map<Poll>(pollDto);
            var poll = await _pollService.AddAsync(don);
            var pollsDto = _mapper.Map<PollDto>(don);
            return CreateActionResult(CustomResponseDto<PollDto>.Success(201, pollsDto));
        }
        [HttpPost("{id}"), Authorize(Roles = "Admin"), Authorize(Roles = "User")]
        public async Task<IActionResult> Vote(int pollId,int answerId)
        {
            //var poll = await _pollService.Vote(pollId,answerId);
            //var pollsDto = _mapper.Map<PollDto>(poll);
            //return CreateActionResult(CustomResponseDto<PollDto>.Success(200, pollsDto));
            return Ok("spr");
        }

        [HttpPut, Authorize(Roles = "Admin"), Authorize(Roles = "User")]
        public async Task<IActionResult> Update(PollUpdateDto pollUpdateDto)
        {
            await _pollService.UpdateAsync(_mapper.Map<Poll>(pollUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin"), Authorize(Roles = "User")]
        public async Task<IActionResult> Remove(int id)
        {
            var poll = await _pollService.GetByIdAsync(id);
            await _pollService.RemoveAsync(poll);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}

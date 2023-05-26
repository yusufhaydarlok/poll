using AutoMapper;
using poll_core.Models;
using poll_core.Repositories;
using poll_core.Services;
using poll_core.UnitOfWorks;
using poll_repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_service.Services
{
    public class PollService : Service<Poll>, IPollService
    {
        private readonly IPollService _pollService;
        private readonly IMapper _mapper;
        public PollService(IGenericRepository<Poll> repository, IUnitOfWork unitOfWork, IPollService pollService, IMapper mapper) : base(repository, unitOfWork)
        {
            _pollService = pollService;
            _mapper = mapper;
        }
        public Task testPoll(Poll poll)
        {
            throw new NotImplementedException();
        }
    }
}

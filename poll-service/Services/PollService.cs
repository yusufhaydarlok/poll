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
        private readonly IPollRepository _pollRepository;
        private readonly IMapper _mapper;
        public PollService(IGenericRepository<Poll> repository, IUnitOfWork unitOfWork, IPollRepository pollRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _pollRepository = pollRepository;
            _mapper = mapper;
        }
        public Task Vote(int pollId, int answerId)
        {
            throw new NotImplementedException();
        }
    }
}

using poll_core.Models;
using poll_core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace poll_repository.Repositories
{
    public class PollRepository : GenericRepository<Poll>, IPollRepository
    {
        public PollRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<Poll>> GetPolls()
        {
            throw new NotImplementedException();
        }
    }
}

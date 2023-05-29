using poll_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_core.Services
{
    public interface IPollService : IService<Poll>
    {
        Task Vote(int pollId,int answerId);
    }
}

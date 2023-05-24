using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_core.Models
{
    public class PollVote
    {
        public int PollId { get; set; }
        public Poll Poll { get; set; }
        public int UserId { get; set; }
        public string Option { get; set; }
    }
}

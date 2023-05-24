using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_core.Models
{
    public class Poll : BaseEntity
    {
        public string Question { get; set; }
        public ICollection<PollOption> Options { get; set; }
        public ICollection<PollVote> Votes { get; set; }
    }
}

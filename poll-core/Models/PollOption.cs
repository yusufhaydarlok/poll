using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_core.Models
{
    public class PollOption : BaseEntity
    {
        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }
        public string Answer { get; set; }
        public int VoteCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_core.Models
{
    public class PollVote : BaseEntity
    {
        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }
    }
}

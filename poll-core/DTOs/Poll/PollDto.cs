﻿using poll_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_core.DTOs.Poll
{
    public class PollDto
    {
        public string Question { get; set; }
        public ICollection<PollOptionDto> Options { get; set; }
    }
}

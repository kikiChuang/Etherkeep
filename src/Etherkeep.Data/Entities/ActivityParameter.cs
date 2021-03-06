﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class ActivityParameter
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }

        public virtual Activity Activity { get; set; }
    }
}

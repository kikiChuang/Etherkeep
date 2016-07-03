﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class EmailAddress
    {
        public string Address { get; set; }
        public Guid UserId { get; set; }
        public bool Verified { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual User User { get; set; }

        public virtual UserPrimaryEmailAddress PrimaryEmailAddress { get; set; }
    }
}

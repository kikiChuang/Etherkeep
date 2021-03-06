﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class NotificationParameter
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }

        public virtual Notification Notification { get; set; }
    }
}

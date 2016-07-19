﻿using Caricoin.Core.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int? PaymentRequestId { get; set; }
        public int? ExternalPaymentId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public double Amount { get; set; }
        public PaymentStatus Status { get; set; }

        public virtual PaymentRequest PaymentRequest { get; set; }
        public virtual ExternalPayment ExternalPayment { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}

﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models
{
    public class UserWalletModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("confirmedBalance")]
        public double ConfirmedBalance { get; set; }
    }
}

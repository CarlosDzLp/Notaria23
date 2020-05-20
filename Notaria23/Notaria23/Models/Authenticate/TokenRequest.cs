﻿using System;
using Newtonsoft.Json;

namespace Notaria23.Models.Authenticate
{
    public class TokenRequest
    {
        [JsonProperty("Token")]
        public string Token { get; set; }

        [JsonProperty("Expired")]
        public int Expired { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }
    }
}

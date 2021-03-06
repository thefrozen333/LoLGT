﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
   public class Champion
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("Id")]
        public int ChampionId { get; set; }
        [JsonIgnore]
        public string ChampionName { get; set; }
        public int StatsId { get; set; }
        public Stats Stats { get; set; }
    }
}

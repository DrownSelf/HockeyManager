using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.Models
{
    public class Splits
    {
        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("stat")]
        public Stats Stats { get; set; }
    }
}

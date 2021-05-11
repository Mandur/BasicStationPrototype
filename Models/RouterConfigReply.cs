using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BasicStationPrototype.Models
{
    public class RouterConfigReply
    {
        public string msgtype { get; set; } = "router_config";
        public List<int> NetID { get; set; } = new List<int> { 1 };
        [JsonPropertyName("DRs")]
        public List<List<int>> DRs { get; set; } = new List<List<int>>
        {
            new List<int>{
                12,
                125,
                0,
            },
            new List<int>
            {
                 11,
                125,
               0,
            },
            new List<int>
            {
                 10,
                125,
               0,
            },
            new List<int>
            {
                 9,
                125,
               0,
            },
            new List<int>
            {
                 8,
                125,
                0,
            },
            new List<int>
            {
                7,
                125,
                0,
            },
            new List<int>
            {
                7,
                250,
                0,
            },
        };
        public  string hwspec { get; set; } = "sx1301/1";
        public  string region { get; set; } = "EU863";
        public  bool nocca { get; set; } = true;
        public  bool nodc { get; set; }  = true;
        public  bool nodwell { get; set; } = true;
        public List<Sx1301> sx1301_conf { get; set; }
    }
}

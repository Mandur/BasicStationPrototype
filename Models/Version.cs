using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicStationPrototype.Models
{
    public class Version
    {
          public string msgtype { get; set; }
          public string station { get; set; }
        public string firmware { get; set; }
        public string package { get; set; }
        public string model { get; set; }
        public int protocol { get; set; }
        public string features { get; set; }
    }
}

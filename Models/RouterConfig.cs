using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BasicStationPrototype.Models
{

    public class Sx1301
    {
        public Radio radio_0 { get; set; }
        public Radio radio_1 { get; set; }
        public Chan_FSK chan_FSK { get; set; }
        public Chan_Lora_Std chan_Lora_std { get; set; }

        public Chan_Multisf chan_multiSF_0 { get; set; }
        public Chan_Multisf chan_multiSF_1 { get; set; }
        public Chan_Multisf chan_multiSF_2 { get; set; }
        public Chan_Multisf chan_multiSF_3 { get; set; }
        public Chan_Multisf chan_multiSF_4 { get; set; }
        public Chan_Multisf chan_multiSF_5 { get; set; }
        public Chan_Multisf chan_multiSF_6 { get; set; }

        public Chan_Multisf chan_multiSF_7 { get; set; }

        public Sx1301()
        {
            radio_0 = new Radio
            {
                enable = true,
                freq = 867500000,
            };
            radio_1 = new Radio
            {
                enable = true,
                freq = 868500000,
            };
            chan_FSK = new Chan_FSK
            {
                enable = true,
                radio = 1,
                _if = 300000,
            };
            chan_Lora_std = new Chan_Lora_Std
            {
                _if = -200000,
                radio = 1,
                enable = true,
                bandwidth = 250000,
                spread_factor = 7,
            };

            chan_multiSF_0 = new Chan_Multisf
            {
                enable = true,
                radio = 1,
                _if = -400000
            };
            chan_multiSF_1 = new Chan_Multisf
            {
                enable = true,
                radio = 1,
                _if = -200000
            };
            chan_multiSF_2 = new Chan_Multisf
            {
                enable = true,
                radio = 1,
                _if = 0,
            };
            chan_multiSF_3 = new Chan_Multisf
            {
                enable = true,
                radio = 0,
                _if = -400000
            };
            chan_multiSF_4 = new Chan_Multisf
            {
                enable = true,
                radio = 0,
                _if = -200000
            };
            chan_multiSF_5 = new Chan_Multisf
            {
                enable = true,
                radio = 0,
                _if = 0
            };
            chan_multiSF_6 = new Chan_Multisf
            {
                enable = true,
                radio = 0,
                _if = 200000
            };
            chan_multiSF_7 = new Chan_Multisf
            {
                enable = true,
                radio = 0,
                _if = 400000
            };
        }
    }

    public class Radio
    {
        public bool enable { get; set; }
        public int freq { get; set; }
    }

    public class Chan_FSK
    {
        public bool enable { get; set; }
        public int radio { get; set; }
        [JsonPropertyName("if")]
        public int _if { get; set; }
    }

    public class Chan_Lora_Std
    {
        public bool enable { get; set; }
        public int radio { get; set; }
        [JsonPropertyName("if")]
        public int _if { get; set; }
        public int bandwidth { get; set; }
        public int spread_factor { get; set; }
    }

    public class Chan_Multisf
    {
        public bool enable { get; set; }
        public int radio { get; set; }
        [JsonPropertyName("if")]
        public int _if { get; set; }
    }

}

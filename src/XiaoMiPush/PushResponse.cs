using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoMiPush
{
    public class PushResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        //[JsonProperty("data")]
        //public string Data { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("info")]
        public string Info { get; set; }
    }
}

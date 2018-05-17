using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoMiPush
{
    public class PushResponse
    {
        public string Result { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public int Code { get; set; }
        public string Info { get; set; }
    }
}

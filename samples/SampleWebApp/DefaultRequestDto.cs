using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp
{
    public class BaseRequestDto
    {
        public string Description { get; set; }
        public Dictionary<string,string> ExtraDic { get; set; }
    }
    public class SendByRegistrationIdsRequestDto
    {
        public string Description { get; set; }
        public Dictionary<string, string> ExtraDic { get; set; }
        public string [] RegistrationIds { get; set; }

    }
    public class SendByRegistrationIdRequestDto
    {
        public string Description { get; set; }
        public Dictionary<string, string> ExtraDic { get; set; }
        public string RegistrationId { get; set; }

    }
    public class SendByAliaRequestDto
    {
        public string Description { get; set; }
        public Dictionary<string, string> ExtraDic { get; set; }
        public string Alia { get; set; }

    }
    public class SendByAliasRequestDto
    {
        public string Description { get; set; }
        public Dictionary<string, string> ExtraDic { get; set; }
        public string[] Alias { get; set; }

    }
    public class SendByTopicRequestDto
    {
        public string Description { get; set; }
        public Dictionary<string, string> ExtraDic { get; set; }
        public string Topic { get; set; }

    }
    public class SendByTopicsRequestDto
    {
        public string Description { get; set; }
        public Dictionary<string, string> ExtraDic { get; set; }
        public string[] Topics { get; set; }

    }

}

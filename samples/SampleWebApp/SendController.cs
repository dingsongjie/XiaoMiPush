using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XiaoMiPush;
using XiaoMiPush.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebApp
{
    [Route("Send")]
    public class SendController : Controller
    {
        private readonly IXiaoMiSender _xiaoMiSender;
        public SendController(IXiaoMiSender xiaoMiSender)
        {
            _xiaoMiSender = xiaoMiSender;
        }
        [HttpPost("SendByRegistrationId")]
        public Task<bool> SendByRegistrationId([FromBody] SendByRegistrationIdRequestDto requestParems)
        {
            IOSMessage message = new IOSMessage(requestParems.Description, requestParems.ExtraDic);
            return _xiaoMiSender.SendByRegistrationId(requestParems.RegistrationId, message);
        }
        [HttpPost("SendByRegistrationIds")]
        public Task<bool> SendByRegistrationIds([FromBody] SendByRegistrationIdsRequestDto requestParems)
        {
            IOSMessage message = new IOSMessage(requestParems.Description, requestParems.ExtraDic);
            return _xiaoMiSender.SendByRegistrationIds(requestParems.RegistrationIds, message);
        }
        [HttpPost("SendByAlia")]
        public Task<bool> SendByAlia([FromBody] SendByAliaRequestDto requestParems)
        {
            IOSMessage message = new IOSMessage(requestParems.Description, requestParems.ExtraDic);
            return _xiaoMiSender.SendByAlia(requestParems.Alia, message);
        }
        [HttpPost("SendByAlias")]
        public Task<bool> SendByAlias([FromBody] SendByAliasRequestDto requestParems)
        {
            IOSMessage message = new IOSMessage(requestParems.Description, requestParems.ExtraDic);
            return _xiaoMiSender.SendByAlias(requestParems.Alias, message);
        }
        [HttpPost("SendByTopic")]
        public Task<bool> SendByTopic([FromBody] SendByTopicRequestDto requestParems)
        {
            IOSMessage message = new IOSMessage(requestParems.Description, requestParems.ExtraDic);
            return _xiaoMiSender.SendByTopic(requestParems.Topic, message);
        }
        [HttpPost("SendByTopics")]
        public Task<bool> SendByTopics([FromBody] SendByTopicsRequestDto requestParems)
        {
            IOSMessage message = new IOSMessage(requestParems.Description, requestParems.ExtraDic);
            return _xiaoMiSender.SendByTopics(requestParems.Topics, message);
        }
        [HttpPost("SendToAll")]
        public Task<bool> SendToAll([FromBody] BaseRequestDto requestParems)
        {
            IOSMessage message = new IOSMessage(requestParems.Description, requestParems.ExtraDic);
            return _xiaoMiSender.SendToAll(message);
        }

    }
}

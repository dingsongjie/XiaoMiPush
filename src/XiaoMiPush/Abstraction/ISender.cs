using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XiaoMiPush.Abstraction
{
    public interface IXiaoMiSender
    {
        Task<bool> SendByRegistrationIds(string[] registrationIds, IOSMessage message);
        Task<bool> SendByAlias(string[] alias, IOSMessage message);
        Task<bool> SendByTopics(string[] topics, IOSMessage message);
        Task<bool> SendByRegistrationId(string registrationId, IOSMessage message);
        Task<bool> SendByAlia(string alia, IOSMessage message);
        Task<bool> SendByTopic(string topic, IOSMessage message);
        Task<bool> SendToAll( IOSMessage message);
    }
}

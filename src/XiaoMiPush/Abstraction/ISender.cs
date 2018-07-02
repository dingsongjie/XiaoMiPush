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
    }
}

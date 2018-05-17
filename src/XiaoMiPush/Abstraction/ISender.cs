using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XiaoMiPush.Abstraction
{
    public interface IXiaoMiSender
    {
        Task<bool> Send(string[] registrationIds, IOSMessage message);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using XiaoMiPush.Abstraction;
using Xunit;

namespace XiaoMiPush.Test.SenderV3
{
    public class SenderV3SendByRegistrationIdsTest
    {
        private readonly IXiaoMiSender _sender = new XiaoMiPush.SenderV3(new DefaultHttpClient(new DefaultHttpContentStrGenerator()), new EmptyLoggerXiaoMiPushLoggerFactory(), new Option() { UseSandbox = true, AppSercet = "+=" });
        [Fact]
        public void SendToSandBox()
        {
            //_sender.SendByRegistrationIds("")
        }
    }
}

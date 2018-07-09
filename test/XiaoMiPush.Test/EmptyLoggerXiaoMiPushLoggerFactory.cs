using System;
using System.Collections.Generic;
using System.Text;
using XiaoMiPush.Abstraction;

namespace XiaoMiPush.Test
{
    public class EmptyLoggerXiaoMiPushLoggerFactory : AbstractXiaoMiPushLoggerFactory
    {
        

        public override ILogger GetLogger(Type type)
        {
            return new EmptyLogger();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoMiPush.Abstraction
{
   public abstract class AbstractXiaoMiPushLoggerFactory
    {
        public abstract ILogger GetLogger(Type type);
        
    }
}

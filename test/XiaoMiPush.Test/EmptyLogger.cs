using System;
using System.Collections.Generic;
using System.Text;
using XiaoMiPush.Abstraction;

namespace XiaoMiPush.Test
{
    public class EmptyLogger : ILogger
    {
        public void Error(string description, string info)
        {
            return;
        }

        public void Error(string message, Exception e)
        {
            return;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoMiPush.Abstraction
{
    public interface ILogger
    {
        void Error(string description, string info);
        void Error(string message, Exception e);
    }
}

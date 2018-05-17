
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using XiaoMiPush.Abstraction;

namespace XiaoMiPush.Extensions.DependencyInjection
{
    class AspnetCoreLogger : Abstraction.ILogger
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public AspnetCoreLogger(Microsoft.Extensions.Logging.ILogger logger)
        {
            _logger = logger;
        }
        public void Error(string description, string info)
        {
            _logger.LogError($"{description},{info}");
        }

        public void Error(string message, Exception e)
        {
            _logger.LogError(message,e);
        }
    }
}

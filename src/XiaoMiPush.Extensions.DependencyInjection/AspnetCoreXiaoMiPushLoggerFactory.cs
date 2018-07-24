using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using XiaoMiPush.Abstraction;

namespace XiaoMiPush.Extensions.DependencyInjection
{
    class AspnetCoreXiaoMiPushLoggerFactory : AbstractXiaoMiPushLoggerFactory
    {
        private readonly ILoggerFactory _logger;
        public AspnetCoreXiaoMiPushLoggerFactory(ILoggerFactory logger)
        {
            _logger = logger;
        }
        public override Abstraction.ILogger GetLogger(Type type)
        {
            return new AspnetCoreLogger(_logger.CreateLogger(type));
        }
    }
}

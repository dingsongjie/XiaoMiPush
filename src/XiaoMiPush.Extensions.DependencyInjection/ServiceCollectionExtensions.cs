using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using XiaoMiPush.Abstraction;

namespace XiaoMiPush.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddXiaoMiPush(this IServiceCollection services, Action<XiaoMiPushOption> optionConfig)
        {
            services.AddSingleton<AbstractXiaoMiPushLoggerFactory, AspnetCoreXiaoMiPushLoggerFactory>();
            services.AddSingleton<DefaultHttpClient>();
            services.AddTransient<IXiaoMiSender, SenderV3>();
            XiaoMiPushOption option = new XiaoMiPushOption();
            optionConfig(option);
            services.AddSingleton(option);
            return services;
        }

    }
}

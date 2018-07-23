using System;
using System.Collections.Generic;
using System.Text;
using XiaoMiPush.Abstraction;
using Xunit;

namespace XiaoMiPush.Test.SenderV3k
{
    public class SenderV3SendByRegistrationIdsTest
    {
        private readonly IXiaoMiSender _sender = new XiaoMiPush.SenderV3(new DefaultHttpClient(YourOption.Default), new EmptyLoggerXiaoMiPushLoggerFactory(), YourOption.Default);
        [Fact]
        public async void SendToProductionByRegistrationId()
        {
            IOSMessage iOSMessage = new IOSMessage("测试");

            var result = await _sender.SendByRegistrationId("9Spvb/pcUf5U+A66u/xszUeNo1iGbfFOCCc7D4zJAq8=", iOSMessage);
            Assert.True(result);
        }
        [Fact]
        public async void SendToProductionByAlia()
        {
            IOSMessage iOSMessage = new IOSMessage("测试");

            var result = await _sender.SendByAlia("18367430928", iOSMessage);
            Assert.True(result);
        }
        [Fact]
        public async void SendToProductionByTopic()
        {
            IOSMessage iOSMessage = new IOSMessage("测试");

            var result = await _sender.SendByTopic("教育", iOSMessage);
            Assert.True(result);
        }
        [Fact]
        public async void SendToProductionToAll()
        {
            IOSMessage iOSMessage = new IOSMessage("测试");

            var result = await _sender.SendToAll(iOSMessage);
            Assert.True(result);
        }
    }
}

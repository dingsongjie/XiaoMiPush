using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XiaoMiPush.Abstraction;

namespace XiaoMiPush
{
    public class SenderV3 : IXiaoMiSender
    {
        const string PUSH_BY_REG_ID_API_URL = "https://api.xmpush.xiaomi.com/v3/message/regid";
        const string PUSH_TO_ALL_DEVICE_API_URL = "https://api.xmpush.xiaomi.com/v3/message/all";
        private readonly DefaultHttpClient _defaultHttpClient;
        private readonly ILogger _logger;

        public SenderV3(DefaultHttpClient defaultHttpClient, AbstractXiaoMiPushLoggerFactory abstractXiaoMiPushLoggerFactory)
        {
            _defaultHttpClient = defaultHttpClient;
            _logger = abstractXiaoMiPushLoggerFactory.GetLogger(typeof(SenderV3));
        }

        public async Task<bool> Send(string[] registrationIds, IOSMessage message)
        {
            try
            {
                var registrationIdStr = string.Join(",", registrationIds);
                Dictionary<string, string> parameters = new Dictionary<string, string>(message.ExtraDic);
                parameters.Add("description", message.Description);
                parameters.Add("time_to_live", message.TimeToLive.ToString());
                parameters.Add("time_to_send", message.TimeToSend.ToString());
                parameters.Add("extra.sound_url", message.ExtraSoundUrl.ToString());
                var response = await _defaultHttpClient.Post(parameters, PUSH_BY_REG_ID_API_URL);
                response.EnsureSuccessStatusCode();
                var stringResponseContent = await response.Content.ReadAsStringAsync();
                var responseObj = Newtonsoft.Json.JsonConvert.DeserializeObject<PushResponse>(stringResponseContent);
                if (responseObj.Code == 0 && responseObj.Result == "ok")
                {
                    return true;
                }
                else
                {
                    _logger.Error(responseObj.Description, responseObj.Info);
                    return false;
                }
            }
            catch(Exception e)
            {
                _logger.Error("小米推送出错", e);
                return false;
            }
            
        }
    }
}

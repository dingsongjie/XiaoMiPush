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
        const string PUSH_TO_SINGLE_TOPIC_API_URL = "https://api.xmpush.xiaomi.com/v3/message/topic";
        const string PUSH_BY_ALIAS_API_URL = "https://api.xmpush.xiaomi.com/v3/message/alias";
        //const string PUSH_BY_ACCOUNT_API_URL = "https://api.xmpush.xiaomi.com/v2/message/user_account";
        const string PUSH_TO_MOTIPLE_TOPIC_API_URL = "https://api.xmpush.xiaomi.com/v3/message/multi_topic";
        private readonly DefaultHttpClient _defaultHttpClient;
        private readonly ILogger _logger;

        public SenderV3(DefaultHttpClient defaultHttpClient, AbstractXiaoMiPushLoggerFactory abstractXiaoMiPushLoggerFactory)
        {
            _defaultHttpClient = defaultHttpClient;
            _logger = abstractXiaoMiPushLoggerFactory.GetLogger(typeof(SenderV3));
        }

      
        public async Task<bool> SendByRegistrationIds(string[] registrationIds, IOSMessage message)
        {
            var registrationIdStr = string.Join(",", registrationIds);

            return await Send(parem =>
             {
                 parem.Add("registration_id", registrationIdStr);
             }, PUSH_BY_REG_ID_API_URL, message);

        }
        public async Task<bool> SendByAlias(string[] alias, IOSMessage message)
        {
            var aliasStr = string.Join(",", alias);

            return await Send(parem =>
            {
                parem.Add("alias", aliasStr);
            }, PUSH_BY_ALIAS_API_URL, message);

        }
        private async Task<bool> Send(Action<Dictionary<string, string>> paremeterAction, string apiUrl, IOSMessage message)
        {
            try
            {
                Dictionary<string, string> parameters = GetParements(message);
                paremeterAction(parameters);
                var response = await _defaultHttpClient.Post(parameters, apiUrl);
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
            catch (Exception e)
            {
                _logger.Error("小米推送出错", e);
                return false;
            }

        }
        private Dictionary<string, string> GetParements(IOSMessage message)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>(message.ExtraDic);
            parameters.Add("description", message.Description);
            parameters.Add("time_to_live", message.TimeToLive.ToString());
            parameters.Add("time_to_send", message.TimeToSend.ToString());
            parameters.Add("extra.sound_url", message.ExtraSoundUrl.ToString());
            return parameters;
        }

        public async Task<bool> SendByTopics(string[] topics, IOSMessage message)
        {
            if (topics.Length == 1)
            {
                return await Send(parem =>
                {
                    parem.Add("topic", topics[0]);
                }, PUSH_BY_ALIAS_API_URL, message);
            }
            else
            {
                var topicsStr = string.Join(";$;", topics);
                return await Send(parem =>
                {
                    parem.Add("topics", topicsStr);
                }, PUSH_BY_ALIAS_API_URL, message);
            }                 
        }
    }
}

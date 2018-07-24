using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoMiPush
{
    public class IOSMessage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="description">通知栏的描述</param>
        /// <param name="extraDic">额外要传输的数据 key 以 ”extra.”开头</param>
        /// <param name="timeToLive">可选项。如果用户离线，设置消息在服务器保存的时间，单位：ms。服务器默认最长保留两周。</param>
        /// <param name="timeToSend">可选项。定时发送消息。用自1970年1月1日以来00:00:00.0 UTC时间表示（以毫秒为单位的时间）。注：仅支持七天内的定时消息</param>
        /// <param name="soundUrl">可选项，自定义消息铃声。当值为空时为无声，default为系统默认声音。</param>
        public IOSMessage(string description, Dictionary<string, string> extraDic = null, long timeToLive = 24 * 14 * 60 * 60 * 1000, long? timeToSend = null, string soundUrl = "default")
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }
            Description = description;

            TimeToLive = timeToLive;
            if (extraDic != null)
            {
                ExtraDic = extraDic;
            }
            else
            {
                ExtraDic = new Dictionary<string, string>();
            }
            if (!timeToSend.HasValue)
            {
                TimeToSend = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
            }
            else
            {
                TimeToSend = timeToSend.Value;
            }
            this.ExtraSoundUrl = soundUrl;
        }
        public string Description { get; private set; }
        public long TimeToLive { get; private set; }
        public long TimeToSend { get; private set; }
        public string ExtraSoundUrl { get; private set; }
        public Dictionary<string, string> ExtraDic { get; private set; }
    }
}

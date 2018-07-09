using System;
using System.Collections.Generic;
using System.Text;
using XiaoMiPush.Abstraction;

namespace XiaoMiPush
{
    public class DefaultHttpContentStrGenerator : IHttpContentStrGenerator
    {
        public string Generate(Dictionary<string, string> parameters)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in parameters)
            {
                sb.Append(item.Key).Append("=").Append(item.Value).Append("&");
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            var contentStr = sb.ToString();
            return contentStr;
        }
    }
}

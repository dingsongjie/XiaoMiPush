using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace XiaoMiPush
{
    public class DefaultHttpClient
    {
        private HttpClient _httpClient;

        public DefaultHttpClient(string appSecret)
        {
            if (string.IsNullOrEmpty(appSecret))
            {
                throw new ArgumentNullException(nameof(appSecret));
            }
            _httpClient = new HttpClient();
            var authorizationSb = new StringBuilder();
            authorizationSb.Append("key=").Append(appSecret);
            var authorization = authorizationSb.ToString();
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authorization);

        }
        public Task<HttpResponseMessage> Post(Dictionary<string, string> dic, string url)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in dic)
            {
                sb.Append(item.Key).Append("=").Append(item.Value).Append("&");
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            var contentStr = sb.ToString();
            HttpContent httpContent = new StringContent(contentStr);

            return this._httpClient.PostAsync(url, httpContent);
        }
    }
}

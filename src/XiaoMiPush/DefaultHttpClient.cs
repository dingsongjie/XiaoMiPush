using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XiaoMiPush.Abstraction;

namespace XiaoMiPush
{
    public class DefaultHttpClient
    {
        private HttpClient _httpClient;
        public DefaultHttpClient( XiaoMiPushOption option)
        {
            if (option == null)
            {
                throw new ArgumentNullException(nameof(option));
            }
            _httpClient = new HttpClient();
            var authorizationSb = new StringBuilder();
            authorizationSb.Append("key=").Append(option.AppSercet);
            var authorization = authorizationSb.ToString();
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorization);
        }
        public DefaultHttpClient()
        {


        }
        public Task<HttpResponseMessage> Post(Dictionary<string, string> dic, string url)
        {
            var formContent = new FormUrlEncodedContent(dic);
            return this._httpClient.PostAsync(url, formContent);
        }
    }
}

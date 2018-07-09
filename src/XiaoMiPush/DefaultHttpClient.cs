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
        private IHttpContentStrGenerator _httpContentStrGenerator;
        public DefaultHttpClient(IHttpContentStrGenerator httpContentStrGenerator)
        {
            _httpContentStrGenerator = httpContentStrGenerator;
        }
        public DefaultHttpClient(Option option)
        {
            if (option==null)
            {
                throw new ArgumentNullException(nameof(option));
            }
            _httpClient = new HttpClient();
            var authorizationSb = new StringBuilder();
            authorizationSb.Append("key=").Append(option.AppSercet);
            var authorization = authorizationSb.ToString();
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authorization);

        }
        public Task<HttpResponseMessage> Post(Dictionary<string, string> dic, string url)
        {
            var paramesStr = _httpContentStrGenerator.Generate(dic);
            HttpContent httpContent = new StringContent(paramesStr);

            return this._httpClient.PostAsync(url, httpContent);
        }    
    }
}

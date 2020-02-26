using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LoginSample.Models;
using Newtonsoft.Json;

namespace LoginSample.Data
{
    public class RestService
    {
        HttpClient client;
        string grantType = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("'application/x-www-form-urlencoded' "));
        }

        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grantType));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);
            var weburl = "www.test.com";
            var response = await PostResponse<Token>(weburl, content);
            var dt = new DateTime();
            dt = DateTime.Today;
            response.ExpireDate = dt.AddSeconds(response.ExpireIn);
            return response;
        }

        public async Task<T> PostResponse<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var token = JsonConvert.DeserializeObject<T>(jsonResult);

            return token;
        }
    }
}

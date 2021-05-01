using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace my_stock_server.Helper
{

    public class HttpRequestHelper
    {
        public HttpRequestHelper()
        {
        }

        public static async Task<string> HttpGetRequestAsync(HttpClient client, string uri)
        {
            string result = string.Empty;
            HttpResponseMessage msg = await client.GetAsync(uri);
            result = await msg.Content.ReadAsStringAsync();
            return result;
        }


        public static async Task<string> HttpGetStringRequestAsync(HttpClient client, string uri)
        {
            string result = string.Empty;
            result = await client.GetStringAsync(uri);
            return result;
        }

        public static async Task<string> HttpPostRequest(HttpClient client, string uri, string mediaType, string contentData, int timeout = 20)
        {
            try
            {
                HttpContent contentPost = new StringContent(contentData, Encoding.UTF8, mediaType);
                return await HttpPostRequest(client, uri, contentPost);
            }
            catch (HttpRequestException hex)
            {
                throw hex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> HttpPostRequest(HttpClient client, string uri, HttpContent contentPost, int timeout = 20)
        {
            try
            {
                string result = string.Empty;
                var httpResponse = await client.PostAsync(uri, contentPost);

                if (httpResponse.IsSuccessStatusCode)
                {
                    result = await httpResponse.Content.ReadAsStringAsync();
                    return result;
                }
                return result;
            }
            catch (HttpRequestException hex)
            {
                throw hex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

    }
}

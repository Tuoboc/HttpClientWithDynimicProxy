using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientWithDynimicProxy
{
    public static class HttpClientExtend
    {

        public static async Task<HttpResponseMessage> PostRetryAsync(this HttpClient client, string requestUri, HttpContent content, int tryTimes = 3, int waitSeconds = 5)
        {
            HttpResponseMessage result;
            int errortimes = 0;
            do
            {
                if (errortimes > 0)
                {
                    await Task.Delay(TimeSpan.FromSeconds(waitSeconds));
                }
                result = await client.PostAsync(requestUri, content);
                errortimes++;
            }
            while (result.IsSuccessStatusCode == false && errortimes <= tryTimes);
            return result;
        }

        public static async Task<String> GetStringRetryAsync(this HttpClient client, string requestUri, int tryTimes = 3, int waitSeconds = 5)
        {
            string result = null;
            int errortimes = 0;
            do
            {
                try
                {
                    result = await client.GetStringAsync(requestUri);
                    break;
                }
                catch
                {
                    errortimes++;
                    if (errortimes >= tryTimes)
                        break;
                    else
                        await Task.Delay(TimeSpan.FromSeconds(waitSeconds));
                }
            }
            while (errortimes <= tryTimes);
            return result;
        }
    }
}

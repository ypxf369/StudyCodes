using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GeTuiTest
{
    public class RestApi
    {
        private static string APPID = "J6zO01Mel96f2y1p20AkE8";
        private static string APPKEY = "BijyJI4PjH8uySj2UEm8a4";
        private static string MASTERSECRET = "M8JfUvgtxv5EezSQYecM94";

        public static async Task<string> AuthSignAsync(string appid)
        {
            var timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);
            var data = new
            {
                sign = EncryptHelper.Sha256(APPKEY + timestamp + MASTERSECRET).ToLower(),
                timestamp = timestamp,
                appkey = APPKEY
            };
            using (var http = new HttpClient())
            using (var content = new StringContent(JsonConvert.SerializeObject(data)))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await http.PostAsync(new Uri($"https://restapi.getui.com/v1/{APPID}/auth_sign"), content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> PushMessageToSingleAsync(string authToken)
        {
            var data = new
            {
                message = new
                {
                    appkey = APPKEY,
                    is_offline = true,
                    offline_expire_time = 10000000,
                    msgtype = "notification"
                },
                notification = new
                {
                    style = new
                    {
                        type = 0,
                        text = "请填写通知内容",
                        title = "请填写通知标题"
                    },
                    transmission_type = true,
                    transmission_content = "透传内容111"
                },
                cid = "d1c7b5efe8361f957fab29bed7b4afc2",
                requestid = DateTime.Now.Ticks.ToString()//"12111111111111111111111"
            };

            using (var http = new HttpClient())
            using (var content = new StringContent(JsonConvert.SerializeObject(data)))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                content.Headers.Add("authtoken", authToken);
                var response = await http.PostAsync(new Uri($"https://restapi.getui.com/v1/{APPID}/push_single"), content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> PushMessageToLinkAsync(string authToken)
        {
            var data = new
            {
                message = new
                {
                    appkey = APPKEY,
                    is_offline = true,
                    offline_expire_time = 10000000,
                    msgtype = "link"
                },
                link = new
                {
                    style = new
                    {
                        type = 0,
                        text = "请填写通知内容",
                        title = "请填写通知标题"
                    },
                    url = "www.baidu.com",
                    transmission_type = true,
                    transmission_content = "透传内容111"
                },
                cid = "d1c7b5efe8361f957fab29bed7b4afc2",
                requestid = DateTime.Now.Ticks.ToString()//"12111111111111111111111"
            };

            using (var http = new HttpClient())
            using (var content = new StringContent(JsonConvert.SerializeObject(data)))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                content.Headers.Add("authtoken", authToken);
                var response = await http.PostAsync(new Uri($"https://restapi.getui.com/v1/{APPID}/push_single"), content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// 透传消息模板，只负责消息传递，客户端自定义消息展现，支持Android、IOS
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public static async Task<string> PushMessageToSingleTransmissionAsync(string authToken)
        {
            var data = new
            {
                message = new
                {
                    appkey = APPKEY,
                    is_offline = true,
                    offline_expire_time = 10000000,
                    msgtype = "transmission"
                },
                transmission = new
                {
                    transmission_type = false,
                    transmission_content = "透传内容111"
                },
                push_info = new
                {
                    aps = new
                    {
                        alert = new
                        {
                            title = "请填写通知标题",
                            body = "请填写通知内容"
                        },
                        autoBadge = "+1",
                        content_available = 1
                    },
                    multimedia = new List<object>
                    {
                        new
                        {
                            url="http://ol5mrj259.bkt.clouddn.com/test2.mp4",
                            type=3,
                            only_wifi=true
                        },
                    }
                },
                cid = "d1c7b5efe8361f957fab29bed7b4afc2",
                requestid = DateTime.Now.Ticks.ToString()//"12111111111111111111111"
            };

            using (var http = new HttpClient())
            using (var content = new StringContent(JsonConvert.SerializeObject(data)))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                content.Headers.Add("authtoken", authToken);
                var response = await http.PostAsync(new Uri($"https://restapi.getui.com/v1/{APPID}/push_single"), content);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}

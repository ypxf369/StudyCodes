using System;
using Newtonsoft.Json.Linq;

namespace GeTuiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var authToken = RestApi.AuthSignAsync("").Result;
            dynamic json = JObject.Parse(authToken);
            if (json.result == "ok")
            {
                //var result = RestApi.PushMessageToSingleAsync(json.auth_token.ToString()).Result;
                //var result = RestApi.PushMessageToLinkAsync(json.auth_token.ToString()).Result;
                var result = RestApi.PushMessageToSingleTransmissionAsync(json.auth_token.ToString()).Result;
            }
            
            Console.ReadKey();
        }
    }
}

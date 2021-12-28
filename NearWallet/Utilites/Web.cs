using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Utilites
{
    class Web
    {
        
        public static async Task<dynamic> GetJson (string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebRequest request = WebRequest.Create(url);
            request.Proxy = new WebProxy("127.0.0.1", 8888);
            request.ContentType = "application/json; charset=utf-8";
            try
            {
                WebResponse response = await request.GetResponseAsync();
                string json = string.Empty;
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    json = stream.ReadToEnd();
                }

                dynamic jObject = JsonConvert.DeserializeObject(json);
                return jObject;
            }
            catch
            {
                throw new Exception("There is no response from the server.");
            }


        }
    }
}

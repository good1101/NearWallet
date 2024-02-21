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
            ServicePointManager.SecurityProtocol =  SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; ;

            ServicePointManager
    .ServerCertificateValidationCallback +=
    (sender, cert, chain, sslPolicyErrors) => true;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Accept = "application/json";
            request.Proxy = new WebProxy("127.0.0.1:8888");
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
            catch(Exception e)
            {
                throw new Exception("There is no response from the server. " + e.Message);
            }
        }
    }
}

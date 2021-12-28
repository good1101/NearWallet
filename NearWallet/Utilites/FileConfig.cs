using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace NearWallet.Utilites
{
    class FileConfig
    {
        public static string DIR_CONF = "data";

        public static void Save<T>(string settingName, T data) where T: new()
        {
            string path = GetPathName(settingName);
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json, Encoding.Unicode);
        }

        public static T Load<T>(string settingName) where T: new()
        {
            string path = GetPathName(settingName);

            if (!File.Exists(path))
                return new T();
            string json = File.ReadAllText(path, Encoding.Unicode);
            try
            {
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            catch
            {
                return new T();
            }
        }

        static string GetPathName(string name)
        {
            return $"{DIR_CONF}\\{name}.json";

        }
    }
}

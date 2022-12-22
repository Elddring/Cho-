using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Магазин
{
    public class Json_Serealize
    {
        public static void Serialize<T>(T obj, string filename)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(filename, json);
        }

        public static T Des<T>(string path)
        {
            string json = File.ReadAllText(path);
            T worker = JsonConvert.DeserializeObject<T>(json);
            return worker;
        }
    }
}

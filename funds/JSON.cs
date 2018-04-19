using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
namespace funds
{
    /// <summary>
    /// 解析JSON，仿Javascript风格
    /// </summary>
    public static class JSON
    {

        public static T parse<T>(string jsonString)
        {
            if (jsonString == null || jsonString == "") return default(T);
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            }
        }

        public static string stringify(object jsonObject)
        {
            if (jsonObject == null) return "";
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}

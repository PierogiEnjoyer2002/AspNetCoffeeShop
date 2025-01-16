using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CoffeeShopMVC.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            // serializacja do JSON
            string jsonData = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonData);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string jsonData = session.GetString(key);
            if (jsonData == null)
                return default(T);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
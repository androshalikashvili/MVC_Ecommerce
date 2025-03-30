using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
//using System.Text.Json;

//namespace MVCEcommerce.Heplers
//{
//    public static class SessionExtensions
//    {
//        public static void SetObjectAsJson(this ISession session, string key, object value)
//        {
//            session.SetString(key, JsonConvert.SerializeObject(value, new JsonSerializerSettings
//            {
//                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
//            }));
//        }

//        public static T? GetObjectFromJson<T>(this ISession session, string key)
//        {
//            var value = session.GetString(key);
//            return value == null ? default(T?) : JsonConvert.DeserializeObject<T>(value);
//        }
//    }
//}

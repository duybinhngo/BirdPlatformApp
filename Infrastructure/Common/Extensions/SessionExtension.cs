using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BirdPlatFormApp.Services.Session
{
    public static class SessionExtension
    {
        public static ISession SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
            return session;
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}

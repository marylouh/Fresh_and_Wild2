using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FreshAndWild2.Helpers
{
    public static class SessionHelper
    {
        // GENERER UN CODE DE SESSION
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));

            // session en cours . assembler ( clef, valeur attachée à cette clef = value stocké en Json);

        }

        // RETROUVER UN CODE DE SESSION

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}

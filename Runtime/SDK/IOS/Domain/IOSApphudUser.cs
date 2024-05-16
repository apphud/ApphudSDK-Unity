#if UNITY_IOS

using Apphud.Unity.Domain;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudCurrencyJson
    {
        public string countryCode;
        public string code;
    }

    [Preserve]
    internal sealed class IOSApphudUserJson
    {
        public string userId;
        public IOSApphudCurrencyJson currency;
    }

    internal sealed class IOSApphudUser : ApphudUser
    {
        internal IOSApphudUser(string json) : this(JsonConvert.DeserializeObject<IOSApphudUserJson>(json)) { }

        internal IOSApphudUser(IOSApphudUserJson json)
        {
            UserId = json.userId;
            CurrencyCode = json.currency.code;
            CountryCode = json.currency.countryCode;
        }
    }
}

#endif
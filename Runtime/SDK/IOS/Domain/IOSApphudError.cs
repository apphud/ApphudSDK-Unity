#if UNITY_IOS

using Apphud.Unity.Domain;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudErrorJson
    {
        public string message;
        public int errorCode;
    }

    internal sealed class IOSApphudError : ApphudError
    {
        internal IOSApphudError(string json) : this(JsonConvert.DeserializeObject<IOSApphudErrorJson>(json)) { }

        internal IOSApphudError(IOSApphudErrorJson json)
        {
            Message = json.message;
            ErrorCode = json.errorCode;
        }
    }
}

#endif
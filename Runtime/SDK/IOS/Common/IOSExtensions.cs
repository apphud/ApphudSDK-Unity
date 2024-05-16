
using System;
using Newtonsoft.Json;

namespace Apphud.Unity.IOS.Common
{
    internal static class IOSExtensions
    {
        internal readonly struct AnyType
        {
            public readonly string type;
            public readonly string value;

            internal AnyType(object value)
            {
                type = value.GetType().ToString();
                this.value = value.ToString();
            }
        }

        internal static string ToIOSAnyJson(this object value)
        {
            if (value == null)
            {
                return null;
            }

            return JsonConvert.SerializeObject(new AnyType(value));
        }

        internal static string GetFullMessage(this Exception ex)
        {
            return ex.InnerException == null
                 ? ex.Message
                 : ex.Message + " --> " + ex.InnerException.GetFullMessage();
        }
    }
}
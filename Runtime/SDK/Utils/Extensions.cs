using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Apphud.Unity.Common.Utils
{
    internal static class Extensions
    {
        internal static void InvokeInUIThread<T1, T2, T3>(this Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3)
        {
            UIThreadDispatcher.Enqueue(() => action(p1, p2, p3));
        }

        internal static void InvokeInUIThread<T1, T2>(this Action<T1, T2> action, T1 p1, T2 p2)
        {
            UIThreadDispatcher.Enqueue(() => action(p1, p2));
        }

        internal static void InvokeInUIThread<T>(this Action<T> action, T data)
        {
            UIThreadDispatcher.Enqueue(() => action(data));
        }

        internal static void InvokeInUIThread(this Action action)
        {
            UIThreadDispatcher.Enqueue(action);
        }

        internal static object ToObject(this IntPtr handle, bool unpinHandle)
        {
            if (IntPtr.Zero.Equals(handle)) { return null; }
            var gcHandle = GCHandle.FromIntPtr(handle);
            var result = gcHandle.Target;
            if (unpinHandle) { gcHandle.Free(); }
            return result;
        }

        internal static IntPtr ToIntPtr(this object obj)
        {
            if (obj == null) { return IntPtr.Zero; }
            var handle = GCHandle.Alloc(obj);
            return GCHandle.ToIntPtr(handle);
        }

        internal static IntPtr ActionToIntPtr<T>(this Action<T> action) => action.ToIntPtr();

        internal static string ToIgnoreNullJson(this object data)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(data, Formatting.None, serializerSettings);
        }

        internal static List<OutValueType> ToListFromJson<OutValueType, JsonValueType>(this string json, Func<JsonValueType, OutValueType> convertFunction)
        {
            List<JsonValueType> jsonsList = JsonConvert.DeserializeObject<List<JsonValueType>>(json);
            List<OutValueType> result = new List<OutValueType>();

            for (int i = 0; i < jsonsList.Count; i++)
            {
                result.Add(convertFunction(jsonsList[i]));
            }

            return result;
        }
    }
}
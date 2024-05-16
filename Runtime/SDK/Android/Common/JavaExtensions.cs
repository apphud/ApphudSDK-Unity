using System;
using System.Collections.Generic;
using UnityEngine;

namespace Apphud.Unity.Android
{
    internal static class JavaExtensions
    {
        internal static AndroidJavaObject ToJavaObject(this object value)
        {
            if (value == null)
            {
                return null;
            }

            Type type = value.GetType();

            return Type.GetTypeCode(type) switch
            {
                TypeCode.Boolean => new AndroidJavaObject("java.lang.Boolean", value),
                TypeCode.Int32 => new AndroidJavaObject("java.lang.Integer", value),
                TypeCode.Single => new AndroidJavaObject("java.lang.Float", value),
                TypeCode.Double => new AndroidJavaObject("java.lang.Double", value),
                TypeCode.String => new AndroidJavaObject("java.lang.String", value),
                _ => throw new NotSupportedException($"{type} is not supported as parameter"),
            };
        }

        internal static object ToObject(this AndroidJavaObject javaObject)
        {
            if (javaObject == null)
            {
                return null;
            }

            try
            {
                return javaObject.Call<float>("floatValue");
            }
            catch { }

            try
            {
                return javaObject.Call<double>("doubleValue");
            }
            catch { }

            try
            {
                return javaObject.Call<int>("intValue");
            }
            catch { }

            try
            {
                return javaObject.Call<bool>("booleanValue");
            }
            catch { }

            try
            {
                return javaObject.Call<string>("toString");
            }
            catch { }

            throw new Exception("The object's type was not identified.");
        }

        internal static AndroidJavaObject ToJavaEnum(this Enum target, string fieldName)
        {
            string enumName = target.ToString();

            AndroidJavaClass enumClass = new AndroidJavaClass(fieldName);

            return enumClass.CallStatic<AndroidJavaObject>("valueOf", enumName);
        }

        internal static AndroidJavaObject ToJavaMap<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            AndroidJavaObject javaMap = new AndroidJavaObject("java.util.HashMap");

            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                using (AndroidJavaObject javaKey = pair.Key.ToJavaObject())
                {
                    using (AndroidJavaObject javaValue = pair.Value.ToJavaObject())
                    {
                        javaMap.Call<AndroidJavaObject>("put", javaKey, javaValue);
                    }
                }
            }

            return javaMap;
        }

        internal static Dictionary<TKeyOut, TValueOut> GetDictionary<TKey, TKeyOut, TValue, TValueOut>(this AndroidJavaObject source, string fieldName, Func<TKey, TKeyOut> keyCreateFunction, Func<TValue, TValueOut> valueCreateFunction)
        {
            AndroidJavaObject javaMap = source.Get<AndroidJavaObject>(fieldName);

            if (javaMap == null)
            {
                return null;
            }

            Dictionary<TKeyOut, TValueOut> dictionary = new Dictionary<TKeyOut, TValueOut>();

            using (AndroidJavaObject entrySet = javaMap.Call<AndroidJavaObject>("entrySet"))
            {
                AndroidJavaObject[] array = entrySet.Call<AndroidJavaObject[]>("toArray");

                foreach (AndroidJavaObject entry in array)
                {
                    TKeyOut key = keyCreateFunction(entry.Call<TKey>("getKey"));
                    TValueOut value = valueCreateFunction(entry.Call<TValue>("getValue"));

                    dictionary.Add(key, value);
                }
            }

            return dictionary;
        }

        internal static T GetEnum<T>(this AndroidJavaObject source, string fieldName) where T : struct
        {
            AndroidJavaObject androidEnum = source.Get<AndroidJavaObject>(fieldName);

            return ParseEnum<T>(androidEnum);
        }

        internal static T? GetNullableEnum<T>(this AndroidJavaObject source, string fieldName) where T : struct
        {
            AndroidJavaObject androidEnum = source.Call<AndroidJavaObject>(fieldName);

            if (androidEnum == null)
            {
                return null;
            }

            return ParseEnum<T>(androidEnum);
        }

        internal static T? CallNullableEnum<T>(this AndroidJavaObject source, string fieldName) where T : struct
        {
            AndroidJavaObject androidEnum = source.Call<AndroidJavaObject>(fieldName);

            if (androidEnum == null)
            {
                return null;
            }

            return ParseEnum<T>(androidEnum);
        }

        internal static long? GetNullableLong(this AndroidJavaObject source, string fieldName)
        {
            AndroidJavaObject androidNullableLong = source.Get<AndroidJavaObject>(fieldName);

            if (androidNullableLong == null)
            {
                return null;
            }

            return androidNullableLong.Call<long>("longValue");
        }

        internal static int? GetNullableInt(this AndroidJavaObject source, string fieldName)
        {
            AndroidJavaObject androidNullableInt = source.Get<AndroidJavaObject>(fieldName);

            if (androidNullableInt == null)
            {
                return null;
            }

            return androidNullableInt.Call<int>("intValue");
        }

        internal static T GetJavaNulableObject<T>(this AndroidJavaObject source, string fieldName, Func<AndroidJavaObject, T> creationFunc) where T : class
        {
            AndroidJavaObject objectValue = source.Get<AndroidJavaObject>(fieldName);

            if (objectValue == null)
            {
                return null;
            }

            return creationFunc(objectValue);
        }

        internal static T CallJavaNulableObject<T>(this AndroidJavaObject source, string fieldName, Func<AndroidJavaObject, T> creationFunc) where T : class
        {
            AndroidJavaObject objectValue = source.Call<AndroidJavaObject>(fieldName);

            if (objectValue == null)
            {
                return null;
            }

            return creationFunc(objectValue);
        }

        internal static JavaList<T> CallJavaNulableList<T>(this AndroidJavaObject source, string fieldName, Func<AndroidJavaObject, T> creationFunc) where T : class
        {
            AndroidJavaObject objectValue = source.Call<AndroidJavaObject>(fieldName);

            if (objectValue == null)
            {
                return null;
            }

            return new JavaList<T>(
                objectValue,
                arrayElement => creationFunc(arrayElement)
            );
        }

        private static T ParseEnum<T>(this AndroidJavaObject enumObject)
        {
            return (T)Enum.Parse(typeof(T), enumObject.Call<string>("name"));
        }
    }
}
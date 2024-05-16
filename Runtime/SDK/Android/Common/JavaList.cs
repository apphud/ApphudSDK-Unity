using System;
using System.Collections.Generic;
using UnityEngine;

namespace Apphud.Unity.Android
{
    internal class JavaBaseList<T>
    {
        private readonly List<T> _items = new List<T>();

        internal JavaBaseList(AndroidJavaObject javaObject)
        {
            if (javaObject == null)
            {
                return;
            }

            int size = javaObject.Call<int>("size");
            for (int i = 0; i < size; i++)
            {
                T item = javaObject.Call<T>("get", i);
                _items.Add(item);
            }
        }

        public static implicit operator List<T>(JavaBaseList<T> javaList)
        {
            if (javaList == null)
            {
                return null;
            }

            return javaList._items;
        }
    }

    internal class JavaList<T>
    {
        private readonly List<T> _items = new List<T>();

        internal JavaList(AndroidJavaObject javaObject, Func<AndroidJavaObject, T> converterFunction)
        {
            if (javaObject == null)
            {
                return;
            }

            int size = javaObject.Call<int>("size");
            for (int i = 0; i < size; i++)
            {
                AndroidJavaObject item = javaObject.Call<AndroidJavaObject>("get", i);
                _items.Add(converterFunction(item));
            }
        }

        public static implicit operator List<T>(JavaList<T> javaList)
        {
            if (javaList == null)
            {
                return null;
            }

            return javaList._items;
        }
    }
}
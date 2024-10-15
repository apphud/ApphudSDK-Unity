using System;
using UnityEngine;
using Apphud.Unity.Common.Utils;

namespace Apphud.Unity.Android
{
    internal sealed class KotlinGenericActionWrapper1<T> : AndroidJavaProxy
    {
        private readonly Action<T> _onInvoke;
        private readonly bool _debugMode;

        internal KotlinGenericActionWrapper1(Action<T> onInvoke, bool debugMode) : base("kotlin.jvm.functions.Function1")
        {
            _onInvoke = onInvoke;
        }

        internal object invoke(T arg)
        {
            if (_debugMode)
            {
                try
                {
                    _onInvoke.InvokeInUIThread(arg);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"[Apphud](KotlinGenericActionWrapper1) {ex.Message}");
                }
            }
            else
            {
                _onInvoke.InvokeInUIThread(arg);
            }

            return null;
        }
    }

    internal sealed class KotlinActionWrapper1 : AndroidJavaProxy
    {
        private readonly Action<AndroidJavaObject> _onInvoke;
        private readonly bool _debugMode;

        internal KotlinActionWrapper1(Action<AndroidJavaObject> onInvoke, bool debugMode) : base("kotlin.jvm.functions.Function1")
        {
            _onInvoke = onInvoke;
            _debugMode = debugMode;
        }

        internal AndroidJavaObject invoke(AndroidJavaObject p1)
        {
            if (_debugMode)
            {
                try
                {
                    _onInvoke.InvokeInUIThread(p1);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"[Apphud](KotlinActionWrapper1) {ex.Message}");
                }
            }
            else
            {
                _onInvoke.InvokeInUIThread(p1);
            }

            return null;
        }
    }

    internal sealed class KotlinActionWrapper2 : AndroidJavaProxy
    {
        private readonly Action<AndroidJavaObject, AndroidJavaObject> _onInvoke;
        private readonly bool _debugMode;

        internal KotlinActionWrapper2(Action<AndroidJavaObject, AndroidJavaObject> onInvoke, bool debugMode) : base("kotlin.jvm.functions.Function2")
        {
            _onInvoke = onInvoke;
            _debugMode = debugMode;
        }

        internal AndroidJavaObject invoke(AndroidJavaObject p1, AndroidJavaObject p2)
        {
            if (_debugMode)
            {
                try
                {
                    _onInvoke.InvokeInUIThread(p1, p2);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"[Apphud](KotlinActionWrapper2) {ex.Message}");
                }
            }
            else
            {
                _onInvoke.InvokeInUIThread(p1, p2);
            }
            return null;
        }
    }

    internal sealed class KotlinActionWrapper3 : AndroidJavaProxy
    {
        private readonly Action<AndroidJavaObject, AndroidJavaObject, AndroidJavaObject> _onInvoke;
        private readonly bool _debugMode;

        internal KotlinActionWrapper3(Action<AndroidJavaObject, AndroidJavaObject, AndroidJavaObject> onInvoke, bool debugMode) : base("kotlin.jvm.functions.Function3")
        {
            _onInvoke = onInvoke;
            _debugMode = debugMode;
        }

        internal AndroidJavaObject invoke(AndroidJavaObject p1, AndroidJavaObject p2, AndroidJavaObject p3)
        {
            if (_debugMode)
            {
                try
                {
                    _onInvoke.InvokeInUIThread(p1, p2, p3);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"[Apphud](KotlinActionWrapper3) {ex.Message}");
                }
            }
            else
            {
                _onInvoke.InvokeInUIThread(p1, p2, p3);
            }
            return null;
        }
    }
}
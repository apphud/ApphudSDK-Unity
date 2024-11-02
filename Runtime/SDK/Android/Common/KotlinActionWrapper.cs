using System;
using UnityEngine;
using Apphud.Unity.Common.Utils;

namespace Apphud.Unity.Android
{
    internal sealed class KotlinActionWrapper1 : KotlinGenericActionWrapper<AndroidJavaObject>
    {
        internal KotlinActionWrapper1(Action<AndroidJavaObject> onInvoke, bool debugMode) : base(onInvoke, debugMode)
        {
        }
    }

    internal sealed class KotlinActionWrapper2 : KotlinGenericActionWrapper<AndroidJavaObject, AndroidJavaObject>
    {
        internal KotlinActionWrapper2(Action<AndroidJavaObject, AndroidJavaObject> onInvoke, bool debugMode) : base(onInvoke, debugMode)
        {
        }
    }

    internal sealed class KotlinActionWrapper3 : KotlinGenericActionWrapper<AndroidJavaObject, AndroidJavaObject, AndroidJavaObject>
    {
        internal KotlinActionWrapper3(Action<AndroidJavaObject, AndroidJavaObject, AndroidJavaObject> onInvoke, bool debugMode) : base(onInvoke, debugMode)
        {
        }
    }

    internal class KotlinGenericActionWrapper<T> : AndroidJavaProxy
    {
        private readonly Action<T> _onInvoke;
        private readonly bool _debugMode;

        internal KotlinGenericActionWrapper(Action<T> onInvoke, bool debugMode) : base("kotlin.jvm.functions.Function1")
        {
            _onInvoke = onInvoke;
            _debugMode = debugMode;
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

    internal class KotlinGenericActionWrapper<T1, T2> : AndroidJavaProxy
    {
        private readonly Action<T1, T2> _onInvoke;
        private readonly bool _debugMode;

        internal KotlinGenericActionWrapper(Action<T1, T2> onInvoke, bool debugMode) : base("kotlin.jvm.functions.Function2")
        {
            _onInvoke = onInvoke;
            _debugMode = debugMode;
        }

        internal AndroidJavaObject invoke(T1 p1, T2 p2)
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

    internal class KotlinGenericActionWrapper<T1, T2, T3> : AndroidJavaProxy
    {
        private readonly Action<T1, T2, T3> _onInvoke;
        private readonly bool _debugMode;

        internal KotlinGenericActionWrapper(Action<T1, T2, T3> onInvoke, bool debugMode) : base("kotlin.jvm.functions.Function3")
        {
            _onInvoke = onInvoke;
            _debugMode = debugMode;
        }

        internal AndroidJavaObject invoke(T1 p1, T2 p2, T3 p3)
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
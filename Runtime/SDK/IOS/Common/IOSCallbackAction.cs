using System;
using System.Runtime.InteropServices;
using Apphud.Unity.Common.Utils;
using UnityEngine;

namespace Apphud.Unity.IOS.Common
{
    internal static class IOSCallbackAction
    {
        public static bool DebugLogsEnabled { get; set; }

        private delegate void CallbackBoolDelegate(IntPtr actionPtr, bool data);
        private delegate void CallbackBoolAndStringDelegate(IntPtr actionPtr, bool data, string data2);
        private delegate void CallbackDelegate(IntPtr actionPtr, string data);
        private delegate void Callback2Delegate(IntPtr actionPtr, string data, string data2);
        private delegate void Callback3Delegate(IntPtr actionPtr, string data, string data2, string data3);

        [AOT.MonoPInvokeCallback(typeof(CallbackDelegate))]
        private static void OnCallbackBool(IntPtr actionPtr, bool data) => InvokeAction(actionPtr, new object[] { data });

        [AOT.MonoPInvokeCallback(typeof(CallbackDelegate))]
        private static void OnCallbackBoolAndString(IntPtr actionPtr, bool data, string data2) => InvokeAction(actionPtr, new object[] { data, data2 });

        [AOT.MonoPInvokeCallback(typeof(CallbackDelegate))]
        private static void OnCallback(IntPtr actionPtr, string data) => InvokeAction(actionPtr, new object[] { data });

        [AOT.MonoPInvokeCallback(typeof(Callback2Delegate))]
        private static void OnCallback2(IntPtr actionPtr, string data, string data2) => InvokeAction(actionPtr, new object[] { data, data2 });

        [AOT.MonoPInvokeCallback(typeof(Callback3Delegate))]
        private static void OnCallback3(IntPtr actionPtr, string data, string data2, string data3) => InvokeAction(actionPtr, new object[] { data, data2, data3 });

        private static void InvokeAction(IntPtr actionPtr, object[] args)
        {
            if (IntPtr.Zero.Equals(actionPtr)) { return; }

            var action = actionPtr.ToObject(true);
            if (action == null) { return; }

            try
            {
                var paramTypes = action.GetType().GetGenericArguments();
                if (paramTypes.Length != args.Length && DebugLogsEnabled)
                {
                    Debug.LogError($"[Apphud](IOSCallbackAction) Argument count mismatch: expected {paramTypes.Length}, got {args.Length}");
                    return;
                }

                var invokeMethod = action.GetType().GetMethod("Invoke", paramTypes);
                if (invokeMethod != null)
                {
                    object[] methodArgs = new object[args.Length];
                    for (int i = 0; i < args.Length; i++)
                    {
                        methodArgs[i] = args[i];
                    }
                    invokeMethod.Invoke(action, methodArgs);
                }
                else if (DebugLogsEnabled)
                {
                    Debug.LogError("[Apphud](IOSCallbackAction) Failed to invoke callback " + action + ": invoke method not found");
                }
            }
            catch (Exception e)
            {
                if (DebugLogsEnabled)
                {
                    Debug.LogError("[Apphud](IOSCallbackAction) Failed to invoke callback " + action + ": " + e.GetFullMessage());
                }
            }
        }

        private static readonly object m_Lock = new object();
        private static bool m_IsInitialized = false;

        internal static void InitializeOnce()
        {
            lock (m_Lock)
            {
                if (!m_IsInitialized)
                {
                    m_IsInitialized = true;
                    RegisterCallbackDelegate(OnCallbackBool, OnCallbackBoolAndString, OnCallback, OnCallback2, OnCallback3);
                }
            }
        }

        [DllImport("__Internal", EntryPoint = "ApphudUnity_registerCallbackHandler")]
        private static extern void RegisterCallbackDelegate(CallbackBoolDelegate callbackBoolDelegate, CallbackBoolAndStringDelegate callbackBoolAndStringDelegate, CallbackDelegate callbackDelegate, Callback2Delegate callback2Delegate, Callback3Delegate callback3Delegate);
    }
}
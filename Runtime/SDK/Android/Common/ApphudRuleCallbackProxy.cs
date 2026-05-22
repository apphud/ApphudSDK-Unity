#if UNITY_ANDROID

using UnityEngine;

namespace Apphud.Unity.Android
{
    internal sealed class ApphudRuleCallbackProxy : AndroidJavaProxy
    {
        internal ApphudRuleCallbackProxy() : base("com.apphud.sdk.ApphudRuleCallback") { }

        public bool shouldPerformRule(AndroidJavaObject rule) => true;

        public bool shouldShowScreen(AndroidJavaObject rule) => true;

        public void onPurchaseCompleted(AndroidJavaObject rule, AndroidJavaObject result) { }
    }
}

#endif

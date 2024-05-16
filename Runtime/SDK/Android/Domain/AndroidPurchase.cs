#if UNITY_ANDROID

using System.Collections.Generic;
using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidPurchase : Purchase
    {
        private AndroidJavaObject _javaObject;
        internal AndroidPurchase(AndroidJavaObject javaObject)
        {
            _javaObject = javaObject;
        }

        public override string GetDeveloperPayload() => _javaObject.Call<string>("getDeveloperPayload");

        public override string GetOrderId() => _javaObject.Call<string>("getOrderId");

        public override string GetOriginalJson() => _javaObject.Call<string>("getOriginalJson");

        public override string GetPackageName() => _javaObject.Call<string>("getPackageName");

        public override int GetPurchaseState() => _javaObject.Call<int>("getPurchaseState");

        public override long GetPurchaseTime() => _javaObject.Call<long>("getPurchaseTime");

        public override string GetPurchaseToken() => _javaObject.Call<string>("getPurchaseToken");

        public override int GetQuantity() => _javaObject.Call<int>("getQuantity");

        public override string GetSignature() => _javaObject.Call<string>("getSignature");

        public override List<string> GetSkus() => new JavaBaseList<string>(_javaObject.Call<AndroidJavaObject>("getSkus"));

        public override List<string> GetProducts() => new JavaBaseList<string>(_javaObject.Call<AndroidJavaObject>("getProducts"));

        public override bool IsAcknowledged() => _javaObject.Call<bool>("isAcknowledged");

        public override bool IsAutoRenewing() => _javaObject.Call<bool>("isAutoRenewing");
    }
}

#endif
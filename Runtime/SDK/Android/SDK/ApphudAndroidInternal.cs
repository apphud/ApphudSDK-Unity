#if UNITY_ANDROID

using System;
using System.Collections.Generic;
using Apphud.Unity.Android.Domain;
using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.SDK
{
    internal static class ApphudAndroidInternal
    {
        private static AndroidJavaObject _instance;
        private static AndroidJavaObject Instance
        {
            get
            {
                if (_instance == null)
                {
                    using (AndroidJavaClass apphud = new AndroidJavaClass("com.apphud.sdk.Apphud"))
                    {
                        _instance = apphud.GetStatic<AndroidJavaObject>("INSTANCE");
                    }
                }
                return _instance;
            }
        }

        private static bool _debugLogsEnabled;

        internal static string UserId => Instance.Call<string>("userId");
        internal static string DeviceId => Instance.Call<string>("deviceId");

        internal static void Start(string apiKey, Action<ApphudUser> callback, bool observerMode)
        {
            Instance.Call(
                "start",
                AndroidApp.CurrentActivity,
                apiKey,
                observerMode,
                new KotlinActionWrapper1(p1 => callback(new AndroidApphudUser(p1)), _debugLogsEnabled)
            );
        }

        internal static void Start(string apiKey, string userId, Action<ApphudUser> callback, bool observerMode)
        {
            Instance.Call(
               "start",
               AndroidApp.CurrentActivity,
               apiKey,
               userId,
               observerMode,
               new KotlinActionWrapper1(p1 => callback(new AndroidApphudUser(p1)), _debugLogsEnabled)
           );
        }

        internal static void DeferPlacements()
        {
            Instance.Call("deferPlacements");
        }

        internal static void ForceFlushUserProperties(Action<bool> completion)
        {
            Instance.Call("forceFlushUserProperties", new KotlinGenericActionWrapper<bool>(completion, _debugLogsEnabled));
        }

        internal static void LogOut() => Instance.Call("logout");
        internal static void UpdateUserId(string userId, Action<AndroidApphudUser> callback)
        {
            Instance.Call("updateUserId", userId, new KotlinActionWrapper1(p1 =>
            {
                callback(p1 != null ? new AndroidApphudUser(p1) : null);
            }, _debugLogsEnabled));
        }

        internal static void FetchPlacements(Action<List<ApphudPlacement>, ApphudError> callback, int? maxAttempts)
        {
            using (AndroidJavaClass apphudClass = new AndroidJavaClass("com.apphud.sdk.ApphudErrorKt"))
            {
                double defaultMaxTimeout = apphudClass.GetStatic<double>("APPHUD_DEFAULT_MAX_TIMEOUT");

                Instance.Call(
                    "fetchPlacements",
                    defaultMaxTimeout,
                    new KotlinActionWrapper2((javaApphudPlacementList, javaApphudError) => callback(
                        new JavaList<ApphudPlacement>(
                            javaApphudPlacementList,
                            javaApphudPlacement => new AndroidApphudPlacement(javaApphudPlacement)
                        ),
                        javaApphudError != null ? new AndroidApphudError(javaApphudError) : null),
                        _debugLogsEnabled
                    )
                );
            }
        }

        internal static void PaywallsDidLoadCallback(Action<List<ApphudPaywall>, ApphudError> callback, int? maxAttempts)
        {
            using (AndroidJavaClass apphudClass = new AndroidJavaClass("com.apphud.sdk.ApphudErrorKt"))
            {
                double defaultMaxTimeout = apphudClass.GetStatic<double>("APPHUD_DEFAULT_MAX_TIMEOUT");

                Instance.Call(
                    "paywallsDidLoadCallback",
                    defaultMaxTimeout,
                    new KotlinActionWrapper2((javaApphudPaywallsList, javaApphudError) => callback(
                        new JavaList<ApphudPaywall>(
                            javaApphudPaywallsList,
                            javaApphudPaywall => new AndroidApphudPaywall(javaApphudPaywall)
                        ),
                        javaApphudError != null ? new AndroidApphudError(javaApphudError) : null),
                        _debugLogsEnabled
                    )
                );
            }
        }


        internal static void LoadFallbackPaywalls(Action<List<ApphudPaywall>, ApphudError> callback)
        {
            Instance.Call(
                "loadFallbackPaywalls",
                new KotlinActionWrapper2((javaApphudPaywallsList, javaApphudError) => callback(
                    new JavaList<ApphudPaywall>(
                        javaApphudPaywallsList,
                        javaApphudPaywall => new AndroidApphudPaywall(javaApphudPaywall)
                    ),
                    javaApphudError != null ? new AndroidApphudError(javaApphudError) : null),
                    _debugLogsEnabled
                )
            );
        }

        internal static List<ApphudSubscription> Subscriptions()
        {
            AndroidJavaObject javaApphudSubscriptionsList = Instance.Call<AndroidJavaObject>("subscriptions");

            return new JavaList<ApphudSubscription>(
                javaApphudSubscriptionsList,
                javaApphudSubscription => new AndroidApphudSubscription(javaApphudSubscription)
            );
        }

        internal static List<ApphudNonRenewingPurchase> NonRenewingPurchases()
        {
            AndroidJavaObject javaApphudNonRenewingPurchases = Instance.Call<AndroidJavaObject>("nonRenewingPurchases");

            return new JavaList<ApphudNonRenewingPurchase>(
                javaApphudNonRenewingPurchases,
                javaApphudSubscription => new AndroidApphudNonRenewingPurchase(javaApphudSubscription)
            );
        }

        internal static void PaywallShown(ApphudPaywall paywall)
        {
            Instance.Call("paywallShown", AndroidApphudPaywall.GetJavaObject(paywall));
        }

        internal static void PaywallClosed(ApphudPaywall paywall)
        {
            Instance.Call("paywallClosed", AndroidApphudPaywall.GetJavaObject(paywall));
        }

        internal static void Purchase(ApphudProduct product, string offerIdToken = null, string oldToken = null, int? replacementMode = null, bool consumableInAppProduct = false, Action<ApphudPurchaseResult> callback = null)
        {
            Instance.Call(
                 "purchase",
                 AndroidApp.CurrentActivity,
                 AndroidApphudProduct.GetJavaObject(product),
                 offerIdToken,
                 oldToken,
                 replacementMode,
                 consumableInAppProduct,
                 new KotlinActionWrapper1(javaPurchaseResult => callback(new AndroidApphudPurchaseResult(javaPurchaseResult)), _debugLogsEnabled)
             );
        }

        internal static void RestorePurchases(Action<List<ApphudSubscription>, List<ApphudNonRenewingPurchase>, ApphudError> callback)
        {
            Instance.Call(
                  "restorePurchases",
                  new KotlinActionWrapper3((javaApphudSubscriptionsList, javaApphudNonRenewingPurchasesList, javaApphudError) => callback(
                      new JavaList<ApphudSubscription>(
                          javaApphudSubscriptionsList,
                          javaApphudSubscription => new AndroidApphudSubscription(javaApphudSubscription)
                      ),
                      new JavaList<ApphudNonRenewingPurchase>(
                          javaApphudNonRenewingPurchasesList,
                          javaApphudNonRenewingPurchase => new AndroidApphudNonRenewingPurchase(javaApphudNonRenewingPurchase)
                      ),
                      javaApphudError != null ? new AndroidApphudError(javaApphudError) : null),
                      _debugLogsEnabled
                  )
              );
        }

        internal static void GrantPromotional(int daysCount, Action<bool> callback)
        {
            Instance.Call("grantPromotional", daysCount, null, null, new KotlinGenericActionWrapper<bool>(callback, _debugLogsEnabled));
        }

        internal static void RefreshUserData(Action<ApphudUser> callback)
        {
            Instance.Call(
                "refreshUserData",
                new KotlinActionWrapper1(p1 => callback(new AndroidApphudUser(p1)), _debugLogsEnabled)
            );
        }

        internal static bool HasPremiumAccess() => Instance.Call<bool>("hasPremiumAccess");
        internal static bool HasActiveSubscription() => Instance.Call<bool>("hasActiveSubscription");
        internal static bool IsNonRenewingPurchaseActive(string productId) => Instance.Call<bool>("isNonRenewingPurchaseActive", productId);

        internal static void EnableDebugLogs()
        {
            _debugLogsEnabled = true;
            Instance.Call("enableDebugLogs");
        }

        internal static void CollectDeviceIdentifiers() => Instance.Call("collectDeviceIdentifiers");
        internal static void OptOutOfTracking() => Instance.Call("optOutOfTracking");

        internal static void SetUserProperty(ApphudUserPropertyKey key, object value, bool setOnce)
        {
            using (AndroidJavaObject javaAny = value.ToJavaObject())
            {
                Instance.Call("setUserProperty", key.GetJavaObject(), javaAny, setOnce);
            }
        }

        internal static void IncrementUserProperty(ApphudUserPropertyKey key, object by)
        {
            using (AndroidJavaObject javaAny = by.ToJavaObject())
            {
                Instance.Call("incrementUserProperty", key.GetJavaObject(), javaAny);
            }
        }

        internal static void SetAttribution(ApphudAttributionProvider provider, ApphudAttributionData data = null, string identifier = null)
        {
            AndroidApphudAttributionData androidData = new(data);
            Instance.Call("setAttribution", androidData.JavaObject, provider.ToJavaEnum("com.apphud.sdk.ApphudAttributionProvider"), identifier);
        }

        internal static void AttributeFromWeb(Dictionary<string, object> data, Action<bool, ApphudUser> callback)
        {
            Instance.Call(
                "attributeFromWeb",
                data.ToJavaMap(false),
                new KotlinGenericActionWrapper<bool, AndroidJavaObject>(
                    (p1, p2) => callback(p1, new AndroidApphudUser(p2)),
                    _debugLogsEnabled
                )
            );
        }

        internal static bool IsFallbackMode()
        {
            return Instance.Call<bool>("isFallbackMode");
        }

        internal static void InvalidatePaywallsCache()
        {
            Instance.Call("invalidatePaywallsCache");
        }

        internal static void TrackPurchase(string productID, string offerIdToken, string paywallIdentifier, string placementIdentifier)
        {
            Instance.Call("trackPurchase", productID, offerIdToken, paywallIdentifier, placementIdentifier);
        }

        internal static void SetHeaders()
        {
            using (var headersInterceptor = new AndroidJavaClass("com.apphud.sdk.managers.HeadersInterceptor"))
            {
                headersInterceptor.SetStatic("X_SDK_VERSION", "1.1.0");
                headersInterceptor.SetStatic("X_SDK", "unity");
            }
        }
    }
}

#endif
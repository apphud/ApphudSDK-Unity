using System;
using System.Collections.Generic;
using Apphud.Unity.Common;
using Apphud.Unity.Domain;

#if UNITY_EDITOR
using Apphud.Unity.Editor;
#elif UNITY_ANDROID
using Apphud.Unity.Android.SDK;
#elif UNITY_IOS
using Apphud.Unity.IOS.SDK;
#endif

namespace Apphud.Unity.SDK
{
    public static class ApphudSDK
    {
#if UNITY_EDITOR
        private static readonly IApphudSDK _sdk = new ApphudEditorSDK();
#elif UNITY_ANDROID
        private static readonly IApphudSDK _sdk = new ApphudAndroidSDK();
#elif UNITY_IOS
        private static readonly IApphudSDK _sdk = new ApphudIOSSDK();
#endif

        /// <summary>
        /// Retrieves the current user ID that identifies the user across multiple devices.
        /// </summary>
        public static string UserId => _sdk.UserId;

        /// <summary>
        /// Retrieves the current device ID. This is useful if you want to implement
        /// a custom logout/login flow by saving the User ID and Device ID pair for each app user.
        /// </summary>
        public static string DeviceId => _sdk.DeviceId;

        /// <summary>
        /// Initializes the Apphud SDK. This method should be called during the app launch.
        /// </summary>
        /// <param name="apiKey">Your API key. This is a required parameter.</param>
        /// <param name="observerMode">
        /// Optional. Sets SDK to Observer (Analytics) mode.
        /// If you purchase products by your own code, then pass `true`. 
        /// If you purchase products using `Apphud.purchase(product)` method, then pass `false`.
        /// Default value is `false`.
        /// </param>
        /// <param name="callback">(Optional) A callback function that is invoked with the `ApphudUser` object after the SDK initialization is complete. 
        /// __Note__: Do not store `ApphudUser`instance in your own code, since it may change at runtime.
        /// </param>
        public static void Start(string apiKey, Action<ApphudUser> callback, bool observerMode = false) => _sdk.Start(apiKey, callback, observerMode);

        /// <summary>
        /// Initializes the Apphud SDK. This method should be called during the app launch.
        /// </summary>
        /// <param name="apiKey">Your API key. This is a required parameter.</param>
        /// <param name="userId">(Optional) A unique user identifier. If null is passed, a UUID will be generated and used as the user identifier.</param>
        /// <param name="observerMode">
        /// Optional. Sets SDK to Observer (Analytics) mode.
        /// If you purchase products by your own code, then pass `true`. 
        /// If you purchase products using `Apphud.purchase(product)` method, then pass `false`.
        /// Default value is `false`.
        /// </param>
        /// <param name="callback">(Optional) A callback function that is invoked with the `ApphudUser` object after the SDK initialization is complete. 
        /// __Note__: Do not store `ApphudUser`instance in your own code, since it may change at runtime.
        /// </param>
        public static void Start(string apiKey, string userId, Action<ApphudUser> callback, bool observerMode = false) => _sdk.Start(apiKey, userId, callback, observerMode);

        /// <summary>
        /// Disables automatic paywall and placement requests during the SDK's initial setup.
        /// Developers must explicitly call `FetchPlacements` method at a later point in the app's lifecycle to fetch placements with inner paywalls.
        /// </summary>
        public static void DeferPlacements() => _sdk.DeferPlacements();

        /// <summary>
        /// This method sends all user properties immediately to Apphud.
        /// Should be used for audience segmentation in placements based on user properties.
        /// </summary>
        public static void ForceFlushUserProperties(Action<bool> completion) => _sdk.ForceFlushUserProperties(completion);


        /// <summary>
        /// Use this method if you have a custom login system with your own backend logic.
        /// It effectively logs out the current user in the context of the Apphud SDK.
        /// </summary>
        public static void LogOut() => _sdk.LogOut();

        /// <summary>
        /// Updates the user ID. This method should only be called after the user is registered.
        /// </summary>
        /// <param name="userId">The new user ID value to be set.</param>
        public static void UpdateUserId(string userId) => _sdk.UpdateUserId(userId);

        /// <summary>
        /// Returns the placements from Product Hub > Placements, potentially altered
        /// based on the user's involvement in A/B testing, if applicable.
        /// 
        /// __Note:__ Method waits until the inner `ProductDetails` or 'SKProduct' are loaded from Google Play or App Store.
        /// 
        /// A placement is a specific location within a user's journey
        ///  (such as onboarding, settings, etc.) where its internal paywall is intended to be displayed.
        ///  
        /// __IMPORTANT:__ The callback may return both placements and an error simultaneously.
        /// If there is an issue with Google Billing or StoreKit Error and inner product details could not be fetched,
        /// an error will be returned along with the raw placements array.
        /// This allows for handling situations where partial data is available.
        /// </summary>
        /// <param name="callback">
        /// The callback function that is invoked with the list of `ApphudPlacement` objects.
        /// Second parameter in callback represents optional error, which may be on Google (BillingClient issue) or Appstore (StoreKit Error) or Apphud side.
        /// </param>
        /// <param name="maxAttempts">Number of request attempts before throwing an error. Must be between 1 and 10. Default value is 3.</param>
        public static void FetchPlacements(Action<List<ApphudPlacement>, ApphudError> callback, int maxAttempts = 3) => _sdk.FetchPlacements(callback, maxAttempts);

        /// <summary>
        /// Returns the paywalls from Product Hub > Paywalls, potentially altered
        /// based on the user's involvement in A/B testing, if applicable.
        /// 
        /// __Note:__ Method waits until the inner `ProductDetails` or 'SKProduct' are loaded from Google Play or App Store.
        /// 
        /// Each paywall contains an array of `ApphudProduct` objects that can be used for purchases.
        /// `ApphudProduct` is Apphud's wrapper around `ProductDetails` or SKProduct.
        /// 
        /// __IMPORTANT:__ The callback may return both paywalls and an error simultaneously.
        /// If there is an issue with Google Billing or StoreKit Error and inner product details could not be fetched,
        /// an error will be returned along with the raw paywalls array.
        /// This allows for handling situations where partial data is available.    
        /// </summary>
        /// <param name="callback">
        /// The callback function that is invoked with the list of `ApphudPaywall` objects.
        /// Second parameter in callback represents optional error, which may be on Google (BillingClient issue) or Appstore (StoreKit Error) or Apphud side.
        /// </param>
        /// <param name="maxAttempts">Number of request attempts before throwing an error. Must be between 1 and 10. Default value is 3.</param>
        public static void PaywallsDidLoadCallback(Action<List<ApphudPaywall>, ApphudError> callback, int maxAttempts = 3) => _sdk.PaywallsDidLoadCallback(callback, maxAttempts);

        /// <summary>
        /// Retrieves all the subscription objects that the user has ever purchased.
        /// The information is cached on the device.
        /// </summary>
        /// <returns>A list of `ApphudSubscription` objects.</returns>
        public static List<ApphudSubscription> Subscriptions() => _sdk.Subscriptions();

        /// <summary>
        /// Retrieves all non-renewing product purchases that the user has ever made.
        /// The information is cached on the device and sorted by purchase date.
        /// </summary>
        /// <returns>A list of `ApphudNonRenewingPurchase` objects.</returns>
        public static List<ApphudNonRenewingPurchase> NonRenewingPurchases() => _sdk.NonRenewingPurchases();

        /// <summary>
        /// Call this method when your paywall screen is displayed to the user.
        /// This is required for A/B testing analysis.
        /// </summary>
        /// <param name="paywall">The `ApphudPaywall` object representing the paywall shown to the user.</param>
        public static void PaywallShown(ApphudPaywall paywall) => _sdk.PaywallShown(paywall);

        /// <summary>
        /// Call this method when your paywall screen is dismissed without a purchase.
        /// This is required for A/B testing analysis.
        /// </summary>
        /// <param name="paywall">The `ApphudPaywall` object representing the paywall that was closed.</param>
        public static void PaywallClosed(ApphudPaywall paywall) => _sdk.PaywallClosed(paywall);

        /// <summary>
        /// Initiates the purchase process for a specified product and automatically
        /// submits the purchase token to Apphud.
        /// </summary>
        /// <param name="product">The `ApphudProduct` object representing the product to be purchased.</param>
        /// <param name="offerIdToken">[Android ONLY](Required for Subscriptions) The identifier of the offer for initiating the purchase.
        /// Developer should retrieve it from SubscriptionOfferDetails array.
        /// If not passed, then SDK will try to use first one from the array.
        /// </param>
        /// <param name="oldToken">[Android ONLY](Optional) The Google Play Billing purchase token that the user is upgrading or downgrading from.
        /// </param>
        /// <param name="replacementMode">
        /// [Android ONLY](Optional) The replacement mode for the subscription update.
        /// </param>
        /// <param name="consumableInAppProduct">
        /// [Android ONLY](Optional) Set to true for consumable products. Otherwise purchase will be treated as non-consumable and acknowledged.
        /// </param>
        /// <param name="callback">(Optional) A callback that returns an `ApphudPurchaseResult` object.</param>
        public static void Purchase(
            ApphudProduct product,
            string offerIdToken = null,
            string oldToken = null,
            int? replacementMode = null,
            bool consumableInAppProduct = false,
            Action<ApphudPurchaseResult> callback = null
        ) => _sdk.Purchase(product, offerIdToken, oldToken, replacementMode, consumableInAppProduct, callback);

        /// <summary>
        /// Implements the 'Restore Purchases' mechanism. 
        /// On Android this method sends the current Play Market Purchase Tokens to Apphud and returns subscription information.
        /// Note: Even if the callback returns some subscription, it doesn't necessarily mean that
        /// the subscription is active. Check `subscription.isActive()` for subscription status.
        /// </summary>
        /// <param name="callback">Required. A callback that returns an array of subscriptions, in-app products, or an optional error.</param>
        public static void RestorePurchases(Action<List<ApphudSubscription>, List<ApphudNonRenewingPurchase>, ApphudError> callback) => _sdk.RestorePurchases(callback);

        /// <summary>
        /// Grants a free promotional subscription to the user.
        /// Returns `true` in the callback if the promotional subscription was successfully granted.
        /// 
        /// Note: Either pass `productId` or `permissionGroup`, or pass both as null.
        /// If both are provided, `productId` will be used.
        /// </summary>
        /// <param name="daysCount">The number of days for the free premium access. For a lifetime promotion, pass a large number.</param>
        /// <param name="productId">(Optional) The product ID of the subscription for the promotion.</param>
        /// <param name="permissionGroup">(Optional) The permission group for the subscription. Use when you have multiple groups.</param>
        /// <param name="callback">(Optional) Returns `true` if the promotional subscription was granted.</param>
        public static void GrantPromotional(int daysCount, string productId = null, ApphudGroup permissionGroup = null, Action<bool> callback = null) => _sdk.GrantPromotional(daysCount, productId, permissionGroup, callback);

        /// <summary>
        /// Determines if the user has active premium access, which includes any active subscription or non-renewing purchase (lifetime).
        /// </summary>
        /// <returns>`true` if the user has an active subscription or non-renewing purchase, `false` otherwise.</returns>
        public static bool HasPremiumAccess() => _sdk.HasPremiumAccess();

        /// <summary>
        /// Checks if the user has an active subscription. The information is cached on the device.
        /// Use this method to determine whether the user has an active premium subscription.
        /// Note: If you offer lifetime purchases, you must use the `isNonRenewingPurchaseActive` method.
        /// </summary>
        /// <returns>`true` if the user has an active subscription, `false` otherwise.</returns>
        public static bool HasActiveSubscription() => _sdk.HasActiveSubscription();

        /// <summary>
        /// Checks if the current user has purchased a specific in-app product.
        /// Returns `false` if the product is refunded or never purchased.
        /// Note: This method considers the most recent purchase of the given product identifier.
        /// </summary>
        /// <param name="productId">The identifier of the product to check.</param>
        /// <returns>`true` if the product is active, `false` otherwise.</returns>
        public static bool IsNonRenewingPurchaseActive(string productId) => _sdk.IsNonRenewingPurchaseActive(productId);

        /// <summary>
        /// Enables debug logs. It is recommended to call this method before SDK initialization.
        /// </summary>
        public static void EnableDebugLogs() => _sdk.EnableDebugLogs();

#if UNITY_ANDROID
        /// <summary>
        /// Refreshes current user data, which includes:
        /// paywalls, placements, subscriptions, non-renewing purchases, or promotionals.
        /// 
        /// __NOTE__: Do not call this method on app launch, as Apphud SDK does it automatically.
        /// 
        /// You can call this method, when the app reactivates from the background, if needed.
        /// </summary>
        public static void RefreshUserData(Action<ApphudUser> callback) => _sdk.RefreshUserData(callback);

        /// <summary>
        /// Collects device identifiers required for some third-party integrations (e.g., AppsFlyer, Adjust, Singular).
        /// Identifiers include Advertising ID, Android ID, App Set ID.
        /// Warning: When targeting Android 13 and above, declare the AD_ID permission in the manifest.
        /// Be sure `optOutOfTracking()` is not called before this, otherwise identifiers will not be collected.
        /// </summary>
        public static void CollectDeviceIdentifiers() => _sdk.CollectDeviceIdentifiers();

        /// <summary>
        /// Returns `true` if fallback mode is on.
        /// That means paywalls are loaded from the fallback json file.
        /// </summary>
        public static bool IsFallbackMode() => _sdk.IsFallbackMode();

        /// <summary>
        /// Tracks a purchase made through Google Play. This method should be used only in Observer Mode,
        /// specifically when utilizing Apphud Paywalls and Placements, and when you need to associate the
        /// purchase with specific paywall and placement identifiers.
        /// 
        /// In all other cases, purchases will be automatically intercepted and sent to Apphud.
        /// 
        /// Note: The `offerIdToken` is mandatory for subscriptions. The `paywallIdentifier` and `placementIdentifier`
        /// are optional but recommended for A/B test analysis in Observer Mode.
        /// </summary>
        /// <param name="productID">The Google Play product ID of the item to purchase.</param>
        /// <param name="offerIdToken">The identifier of the subscription's offer token. This parameter is required for subscriptions.</param>
        /// <param name="paywallIdentifier">(Optional) The identifier of the paywall.</param>
        /// <param name="placementIdentifier">(Optional) The identifier of the placement.</param>
        public static void TrackPurchase(string productID, string offerIdToken = null, string paywallIdentifier = null, string placementIdentifier = null) => _sdk.TrackPurchase(productID, offerIdToken, paywallIdentifier, placementIdentifier);

#elif UNITY_IOS
        /// <summary>
        /// Submits attribution data to Apphud from Apple Search Ads.
        /// For more details, visit https://docs.apphud.com/docs/apple-search-ads
        /// </summary>
        /// <param name="callback">Optional. A closure that returns `true` if the data was successfully sent to Apphud.</param>
        public static void TrackAppleSearchAds() => _sdk.TrackAppleSearchAds();

        /// <summary>
        /// Notifies Apphud when a purchase process is initiated from a paywall in `Observer Mode`, enabling the use of A/B experiments.
        /// This method should be called right before executing your own purchase method, and it's specifically required only when the SDK is in Observer Mode.
        /// </summary>
        /// <param name="paywallIdentifier">Required. The Paywall ID from Apphud Product Hub > Paywalls.</param>
        /// <param name="placementIdentifier"> Optional. The Placement ID from Apphud Product Hub > Placements if using placements; otherwise, pass `nil`.</param>
        public static void WillPurchaseProductFrom(string paywallIdentifier, string placementIdentifier) => _sdk.WillPurchaseProductFrom(paywallIdentifier, placementIdentifier);

        /// <summary>
        /// Submits Device Identifiers (IDFA and IDFV) to Apphud. These identifiers may be required for marketing and attribution platforms such as AppsFlyer, Facebook, Singular, etc.
        /// Best practice is to call this method right after SDK's `start(...)` method and once again after getting IDFA.
        /// </summary>
        /// <param name="idfa">
        /// IDFA. Identifier for Advertisers.
        /// If you request IDFA using App Tracking Transparency framework, you can call this method again after granting access.
        /// You can get it from: [UnityEngine.iOS.Device.advertisingIdentifier]
        /// For more details, visit https://docs.unity.com/ads/en-us/manual/ATTCompliance
        /// </param>
        /// <param name="idfv">
        /// IDFV. Identifier for Vendor.
        /// Can be passed right after SDK's `start` method.
        /// You can get it from: [UnityEngine.iOS.Device.vendorIdentifier]
        /// For more details, visit https://docs.unity.com/ads/en-us/manual/ATTCompliance
        /// </param>
        public static void SetDeviceIdentifiers(string idfa, string idfv) => _sdk.SetDeviceIdentifiers(idfa, idfv);

        /// <summary>
        /// Submits the device's push token to Apphud as a String. This method provides an alternative way to submit the token if you have it in a string format.
        /// </summary>
        /// <param name="str">The push token as a String object.</param>
        /// <param name="callback">An optional closure that returns `true` if the token was successfully sent to Apphud.</param>
        public static void SubmitPushNotificationsTokenString(string str, Action<bool> callback) => _sdk.SubmitPushNotificationsTokenString(str, callback);
#endif

        /// <summary>
        /// Must be called before SDK initialization. If called, certain user parameters
        /// like Advertising ID, Android ID, App Set ID, Device Type, IP address will not be tracked by Apphud.
        /// 
        /// __NOTE__: Consider the privacy implications and ensure compliance
        /// with relevant data protection regulations when opting users out of tracking.
        /// </summary>
        public static void OptOutOfTracking() => _sdk.OptOutOfTracking();

        /// <summary>
        /// Sets a custom user property. The value must be one of the following types:
        /// "int", "float", "double", "bool", "string", or "null".
        /// 
        /// Example:
        /// ApphudSDK.SetUserProperty(ApphudUserPropertyKey.Email, "user@example.com", true);
        /// ApphudSDK.SetUserProperty(ApphudUserPropertyKey.CustomProperty("custom_key"), 0.2f, false);
        /// 
        /// Note: Built-in keys have predefined value types:
        /// "ApphudUserPropertyKey.Email": User email. Value must be String.
        /// "ApphudUserPropertyKey.Name": User name. Value must be String.
        /// "ApphudUserPropertyKey.Phone": User phone number. Value must be String.
        /// "ApphudUserPropertyKey.Age": User age. Value must be Int.
        /// "ApphudUserPropertyKey.Gender": User gender. Value must be one of: "male", "female", "other".
        ///  "ApphudUserPropertyKey.Cohort": User install cohort. Value must be String.
        /// </summary>
        /// <param name="key">The property key, either custom or built-in.</param>
        /// <param name="value">The property value, or "null" to remove the property.</param>
        /// <param name="setOnce">If set to "true", the property cannot be updated later.</param>
        public static void SetUserProperty(ApphudUserPropertyKey key, object value, bool setOnce = false) => _sdk.SetUserProperty(key, value, setOnce);

        /// <summary>
        /// Increments a custom user property. The value to increment must be one of the types:
        /// "int", "float", or "double".
        /// 
        /// Example:
        /// ApphudSDK.IncrementUserProperty(ApphudUserPropertyKey.CustomProperty("custom_key"), 2);
        /// </summary>
        /// <param name="key">The property key, which should be a custom key.</param>
        /// <param name="by">The value to increment the property by. Negative values will decrement.</param>
        public static void IncrementUserProperty(ApphudUserPropertyKey key, object by) => _sdk.IncrementUserProperty(key, by);

        /// <summary>
        /// Submits attribution data to Apphud from your attribution network provider.
        /// </summary>
        /// <param name="provider">Required. Attribution provider name.</param>
        /// <param name="data">Optional. Attribution dictionary.</param>
        /// <param name="identifier">Optional. Identifier that matches Apphud and the Attribution provider.</param>
        /// <param name="callback">Optional. A closure that returns `true` if the data was successfully sent to Apphud.</param>
        public static void AddAttribution(ApphudAttributionProvider provider, Dictionary<string, object> data = null, string identifier = null) => _sdk.AddAttribution(provider, data, identifier);
#if APPHUD_FB
        /// <summary>
        /// Submits attribution data to Apphud from Facebook SDK.
        /// For more details, visit https://docs.apphud.com/docs/facebook-conversions-api
        /// </summary>
        /// <param name="callback">Optional. A callback that returns error message if the data was not successfully sent to Apphud.</param>
        public static void AddFacebookAttribution(Action<string> callback) => _sdk.AddFacebookAttribution(callback);
#endif
        /// <summary>
        /// Explicitly loads fallback paywalls from the json file, if it was added to the project resources.
        /// By default, SDK automatically tries to load paywalls from the JSON file, if possible.
        /// However, developer can also call this method directly for more control.
        /// For more details, visit https://docs.apphud.com/docs/paywalls#set-up-fallback-mode
        /// </summary>
        /// <param name="callback">
        /// The callback function that is invoked with the list of `ApphudPlacement` objects.
        /// Second parameter in callback represents optional error, which may be on Google (BillingClient issue) or Appstore (StoreKit Error) or Apphud side.
        /// </param>
        public static void LoadFallbackPaywalls(Action<List<ApphudPaywall>, ApphudError> callback) => _sdk.LoadFallbackPaywalls(callback);

        /// <summary>
        ///  Must be called before SDK initialization.
        ///  Will make SDK to disregard cache and force refresh paywalls and placements.
        ///  Call it only if keeping paywalls and placements up to date is critical for your app business.
        /// </summary>
        public static void InvalidatePaywallsCache() => _sdk.InvalidatePaywallsCache();
    }
}

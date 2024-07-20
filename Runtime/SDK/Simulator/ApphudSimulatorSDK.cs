using Apphud.Unity.Common;
using Apphud.Unity.Domain;
using System;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;

namespace Apphud.Unity.Simulator {
	public class ApphudSimulatorSDK : IApphudSDK {
		
		public void Start(string apiKey, Action<ApphudUser> callback, bool observerMode) {
		}

		public void Start(string apiKey, string userId, Action<ApphudUser> callback, bool observerMode) {
		}

		public void LogOut() {
		}

		public void UpdateUserId(string userId) {
		}

		public void FetchPlacements(Action<List<ApphudPlacement>, ApphudError> callback, int maxAttempts) {
		}

		public void PaywallsDidLoadCallback(Action<List<ApphudPaywall>, ApphudError> callback, int maxAttempts) {
		}

		public List<ApphudSubscription> Subscriptions() {
			return null;
		}

		public List<ApphudNonRenewingPurchase> NonRenewingPurchases() {
			return null;
		}

		public void PaywallShown(ApphudPaywall paywall) {
		}

		public void PaywallClosed(ApphudPaywall paywall) {
		}

		public void WillPurchaseProductFrom(string placementIdentifier, string paywallIdentifier) {
		}

		public void Purchase(ApphudProduct product, string offerIdToken = null, string oldToken = null, int? replacementMode = null, bool consumableInAppProduct = false, Action<ApphudPurchaseResult> callback = null) {
		}

		public void RestorePurchases(Action<List<ApphudSubscription>, List<ApphudNonRenewingPurchase>, ApphudError> callback) {
		}

		public void GrantPromotional(int daysCount, string productId, ApphudGroup permissionGroup, Action<bool> callback) {
		}

		public bool HasPremiumAccess() {
			return false;
		}

		public bool HasActiveSubscription() {
			return false;
		}

		public bool IsNonRenewingPurchaseActive(string productId) {
			return false;
		}

		public void EnableDebugLogs() {
		}

		public void OptOutOfTracking() {
		}

		public void SetUserProperty(ApphudUserPropertyKey key, object value, bool setOnce) {
		}

		public void IncrementUserProperty(ApphudUserPropertyKey key, object by) {
		}

		public void AddAttribution(ApphudAttributionProvider provider, Dictionary<string, object> data = null, string identifier = null) {
		}

		public void SetDeviceIdentifiers(string idfa, string idfv) {
		}

		public string UserId { get; }
		public string DeviceId { get; }
	}
}
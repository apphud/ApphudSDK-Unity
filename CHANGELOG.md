## [1.5.0] - 2026-05-19

- [Breaking] Removed methods
  - PaywallsDidLoadCallback
  - PaywallClosed
- [Breaking] Modified methods
  - RestorePurchases callback now returns a single ApphudSubscription and a single ApphudNonRenewingPurchase (not lists). On Android, where the native SDK still returns lists, the wrapper picks the first active item (or falls back to the first item if none are active). For full restored history use Subscriptions() / NonRenewingPurchases().
- Modified methods
  - UpdateUserId now accepts optional completion callback
  - FetchPlacements now accepts a forceRefresh flag
  - SetAttribution now accepts optional completion callback
- Updated native iOS SDK to 4.0.4
- Updated native Android SDK to 3.1.0 (Google Billing 8.3.0)

## [1.4.0] - 2025-09-16

- [Breaking] The addAttribution method has been renamed to setAttribution, introducing the new ApphudAttributionData class. This allows developers to override attribution key mappings if needed.

## [1.3.0] - 2024-11-02

- New methods
  - AttributeFromWeb
- Added ErrorCode value to ApphudError on iOS

## [1.2.0] - 2024-10-15

- New methods
  - ForceFlushUserProperties
  - DeferPlacements
- Modified methods
  - RefreshUserData
- Fixed methods
  - GrantPromotional
- Added SKProduct to ApphudProduct on iOS
- Added PurchaseToken to ApphudSubscription and ApphudNonRenewingPurchase

## [1.1.0] - 2024-07-29

- Observer mode
- Editor mode exceptions handling
- New methods
  - LoadFallbackPaywalls
  - AddFacebookAttribution
  - InvalidatePaywallsCache
- New Android methods
  - IsFallbackMode
  - TrackPurchase
- New iOS methods
  - TrackAppleSearchAds
  - WillPurchaseProductFrom
  - SubmitPushNotificationsTokenString

## [1.0.0] - 2024-05-16

### This is the first release of _Apphud Unity SDK_.

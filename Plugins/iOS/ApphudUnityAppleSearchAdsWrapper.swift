import Foundation
import ApphudSDK
import AdServices

@objc final public class ApphudUnityAppleSearchAdsWrapper: NSObject {
    @MainActor
    @objc public static func trackAppleSearchAds(callback: @escaping (Bool) -> Void) {
        if #available(iOS 14.3, *) {
            Task {
                if let asaToken = try? AAAttribution.attributionToken() {
                    Apphud.setAttribution(data: nil, from: .appleAdsAttribution, identifer: asaToken, callback: callback)
                }
            }
        }
    }
}

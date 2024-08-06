import Foundation
import ApphudSDK

@objc final public class ApphudUnityAPIWrapper: NSObject {
    @MainActor
    @objc public static func start(apiKey: String, userID: String?, observerMode: Bool, callback: @escaping (String) -> Void) {
        Apphud.start(apiKey: apiKey, userID: userID, observerMode: observerMode) { user in
            callback(user.toJson())
        }
    }
    
    @MainActor
    @objc public static func start(apiKey: String, observerMode: Bool, callback: @escaping (String) -> Void) {
        Apphud.start(apiKey: apiKey, observerMode: observerMode) { user in
            callback(user.toJson())
        }
    }
    
    @MainActor
    @objc public static func fetchPlacements(maxAttempts: Int, callback: @escaping (String?, String?) -> Void) {
        Apphud.fetchPlacements(maxAttempts: maxAttempts, { placements, error in
            callback(placements.toJson(), error?.localizedDescription)
        })
    }
    
    @MainActor
    @objc public static func paywallsDidLoadCallback(maxAttempts: Int, callback: @escaping (String, String?) -> Void) {
        Apphud.paywallsDidLoadCallback(maxAttempts: maxAttempts, { paywalls, error in
            callback(paywalls.toJson(), error?.localizedDescription)
        })
    }
    
    @MainActor
    @objc public static func subscriptions() -> String? {
        let subscriptions = Apphud.subscriptions()
        return subscriptions?.toJsonListOfMap()
    }
    
    @MainActor
    @objc public static func nonRenewingPurchases() -> String? {
        let nonRenewingPurchases = Apphud.nonRenewingPurchases()
        return nonRenewingPurchases?.toJsonListOfMap()
    }
    
    @MainActor
    @objc public static func paywallShown(identifier:String, placementIdentifier: String?) -> Void {
        Task{@MainActor in
            let paywall = await findPaywall(identifier: identifier, placementIdentifier: placementIdentifier)
            if(paywall != nil) {
                Apphud.paywallShown(paywall!)
            }
        }
    }
    
    @MainActor
    @objc public static func paywallClosed(identifier:String, placementIdentifier: String?) -> Void {
        Task{@MainActor in
            let paywall = await findPaywall(identifier: identifier, placementIdentifier: placementIdentifier)
            if(paywall != nil) {
                Apphud.paywallClosed(paywall!)
            }
        }
    }
    
    @MainActor
    @objc public static func purchase(productId: String, placementIdentifier: String?, paywallIdentifier: String?, callback: @escaping (String) -> Void) {
        
        Task {@MainActor in
            var product:ApphudProduct?
            
            if(placementIdentifier != nil) {
                let placements = await Apphud.placements()
                
                for placemnt in placements where product==nil {
                    let paywall = placemnt.paywall
                    if(paywall != nil) {
                        product = paywall!.products.first { product in
                            return product.productId == productId && product.placementIdentifier == placementIdentifier
                        }
                    }
                }
            }
            else if(paywallIdentifier != nil) {
                let paywalls = await Apphud.paywalls()
                
                for paywall in paywalls where product==nil {
                    product = paywall.products.first { product in
                        return product.productId == productId && product.paywallIdentifier == paywallIdentifier
                    }
                }
            }
            
            guard let product = product else {
                let message = "Cant find product with productId:\(productId), paywallIdentifier:\(String(describing: paywallIdentifier)), placementIdentifier:\(String(describing: placementIdentifier))";
                callback("{\"error\":\"\(message)\"}")
                return
            }
            
            Apphud.purchase(product) { (response) in
                do {
                    let jsonData = try JSONSerialization.data(withJSONObject: response.toMap())
                    if let jsonString = String(data: jsonData, encoding: .utf8) {
                        callback(jsonString)
                    }
                } catch {
                    let message = "Error converting map to JSON: \(error.localizedDescription)"
                    callback("{\"error\":\"\(message)\"}")
                }
            }
        }
    }
    
    @MainActor
    @objc public static func restorePurchases(callback: @escaping (String?, String?, String?) -> Void) -> Void {
        Apphud.restorePurchases() { subscriptions, nonRenewingPurchases, error in
            callback(subscriptions?.toJsonListOfMap(), nonRenewingPurchases?.toJsonListOfMap(), error?.localizedDescription)
        }
    }
    
    @MainActor 
    @objc public static func isNonRenewingPurchaseActive(productIdentifier: String) -> Bool {
        return Apphud.isNonRenewingPurchaseActive(productIdentifier: productIdentifier)
    }
    
    @MainActor
    @objc public static func setUserProperty(key: String, valueJson: String?, setOnce: Bool) -> Void {
        Apphud.setUserProperty(key: .init(key), value: valueJson?.toAnyFromUnityJson(), setOnce: setOnce)
    }
    
    @MainActor
    @objc public static func incrementUserProperty(key: String, byJson: String) -> Void {
        Apphud.incrementUserProperty(key: .init(key), by: byJson.toAnyFromUnityJson()!)
    }
    
    @MainActor
    @objc public static func addAttribution(provider: String, dataJson: String?, identifer: String?, callback: @escaping (Bool) -> Void) -> Void {
        guard let attributionProviderEnum = ApphudAttributionProvider.fromString(provider) else {
            print("Invalid provider string")
            return
        }
        
        var attributionData: [String: Any]?
        
        if let dataJson = dataJson, let data = dataJson.data(using: .utf8) {
            do {
                let object = try JSONSerialization.jsonObject(with: data, options: []) as? [String: Any]
                attributionData = object
            } catch {
                print("Error during JSON deserialization: \(error.localizedDescription)")
            }
        }
        
        Apphud.addAttribution(data: attributionData, from: attributionProviderEnum, identifer: identifer, callback: callback)
    }

    @MainActor
    @objc public static func loadFallbackPaywalls(callback: @escaping (String, String?) -> Void) -> Void {
        Apphud.loadFallbackPaywalls(callback: { paywalls, error in
            callback(paywalls.toJson(), error?.localizedDescription)
        })
    }

    @MainActor
    @objc public static func setHeaders() -> Void {
        ApphudHttpClient.shared.sdkType = "unity"
        ApphudHttpClient.shared.sdkVersion = "1.1.0"
    }
    
    private static func findPaywall(identifier:String, placementIdentifier: String?) async -> ApphudPaywall? {
        if(placementIdentifier != nil) {
            let placements = await Apphud.placements()
            return placements.first(where: {pl in pl.identifier == placementIdentifier})?.paywall
        }
        
        let paywalls = await Apphud.paywalls()
        return paywalls.first(where: { pw in return pw.identifier == identifier })
    }
}

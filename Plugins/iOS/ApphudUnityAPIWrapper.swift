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
    @objc public static func deferPlacements() {
        Apphud.deferPlacements()
    }
    
    @MainActor
    @objc public static func forceFlushUserProperties(completion: @escaping (Bool) -> Void) {
        Apphud.forceFlushUserProperties(completion: completion)
    }
    
    @MainActor
    @objc public static func fetchPlacements(maxAttempts: Int, callback: @escaping (String?, String?) -> Void) {
        Apphud.fetchPlacements(maxAttempts: maxAttempts, { placements, error in
            callback(placements.toJsonListOfMap(), error?.toMap().toJson())
        })
    }
    
    @MainActor
    @objc public static func paywallsDidLoadCallback(maxAttempts: Int, callback: @escaping (String, String?) -> Void) {
        Apphud.paywallsDidLoadCallback(maxAttempts: maxAttempts, { paywalls, error in
            callback(paywalls.toJsonListOfMap(), error?.toMap().toJson())
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
    @objc public static func paywallShown(identifier:String, placementIdentifier: String?) {
        Task{@MainActor in
            let paywall = await findPaywall(identifier: identifier, placementIdentifier: placementIdentifier)
            if(paywall != nil) {
                Apphud.paywallShown(paywall!)
            }
        }
    }
    
    @MainActor
    @objc public static func paywallClosed(identifier:String, placementIdentifier: String?) {
        Task{@MainActor in
            let paywall = await findPaywall(identifier: identifier, placementIdentifier: placementIdentifier)
            if(paywall != nil) {
                Apphud.paywallClosed(paywall!)
            }
        }
    }
    
    @MainActor
    @objc public static func purchase(productId: String?, placementIdentifier: String?, paywallIdentifier: String?, callback: @escaping (String) -> Void) {
        
        Task {@MainActor in
                        
            var product: ApphudProduct?
            
            if let placementID = placementIdentifier {
                let placement = await Apphud.placement(placementID)
                product = placement?.paywall?.products.first { $0.productId == productId }
            }
            
            if let product = product {
                Apphud.purchase(product) { response in
                    handlePurchase(response: response, callback: callback)
                }
            } else if let productId = productId {
                Apphud.paywallsDidLoadCallback { paywalls, error in
                    let paywall = paywalls.first { $0.identifier == paywallIdentifier }
                    product = paywall?.products.first { $0.productId == productId }
                    
                    if let product {
                        Apphud.purchase(product) { response in
                            handlePurchase(response: response, callback: callback)
                        }
                    } else {
                        Apphud.purchase(productId) { response in
                            handlePurchase(response: response, callback: callback)
                        }
                    }
                }
            } else {
                let message = "Cant find product with productId:\(productId), paywallIdentifier:\(String(describing: paywallIdentifier)), placementIdentifier:\(String(describing: placementIdentifier))";
                callback("{\"error\":\"\(message)\"}")
            }
        }
    }
    
    @MainActor
    @objc public static func restorePurchases(callback: @escaping (String?, String?, String?) -> Void) {
        Apphud.restorePurchases() { subscriptions, nonRenewingPurchases, error in
            callback(subscriptions?.toJsonListOfMap(), nonRenewingPurchases?.toJsonListOfMap(), error?.toMap().toJson())
        }
    }
    
    @MainActor 
    @objc public static func isNonRenewingPurchaseActive(productIdentifier: String) -> Bool {
        return Apphud.isNonRenewingPurchaseActive(productIdentifier: productIdentifier)
    }
    
    @MainActor
    @objc public static func setUserProperty(key: String, valueJson: String?, setOnce: Bool) {
        Apphud.setUserProperty(key: .init(key), value: valueJson?.toAnyFromUnityJson(), setOnce: setOnce)
    }
    
    @MainActor
    @objc public static func incrementUserProperty(key: String, byJson: String) {
        Apphud.incrementUserProperty(key: .init(key), by: byJson.toAnyFromUnityJson()!)
    }
    
    @MainActor
    @objc
    public static func setAttribution(provider: String, dataJson: String?, identifer: String?, callback: @escaping (Bool) -> Void) {
        guard let providerEnum = ApphudAttributionProvider.fromString(provider) else {
            print("Invalid provider string: \(provider)")
            callback(false)
            return
        }

        var attributionData: ApphudAttributionData? = nil

        if let dataJson, let data = dataJson.data(using: .utf8) {
            do {
                if let dict = try JSONSerialization.jsonObject(with: data, options: []) as? [String: Any] {
                    attributionData = ApphudAttributionData(
                        rawData:   (dict["rawData"] as? [String: Any]) ?? [:],
                        adNetwork: dict["adNetwork"] as? String,
                        channel:   dict["channel"]   as? String,
                        campaign:  dict["campaign"]  as? String,
                        adSet:     dict["adSet"]     as? String,
                        creative:  dict["creative"]  as? String,
                        keyword:   dict["keyword"]   as? String,
                        custom1:   dict["custom1"]   as? String,
                        custom2:   dict["custom2"]   as? String
                    )
                } else {
                    print("JSON is not a dictionary")
                }
            } catch {
                print("Error during JSON deserialization: \(error.localizedDescription)")
            }
        }

        Apphud.setAttribution(
            data: attributionData,
            from: providerEnum,
            identifer: identifer,
            callback: callback
        )
    }

    @MainActor
    @objc public static func attributeFromWeb(dataJson: String, callback: @escaping (Bool, String?) -> Void) {
        var attributionData: [String: Any] = [:]
        
        if let data = dataJson.data(using: .utf8){
            do {
                if let object = try JSONSerialization.jsonObject(with: data, options: []) as? [String: Any]{
                    attributionData = object
                }else{
                    print("Failed to cast JSON data to a dictionary.")
                }
            } catch {
                print("Error during JSON deserialization: \(error.localizedDescription)")
            }
            
        }
        
        Apphud.attributeFromWeb(data: attributionData) { status, user in
            callback(status, user?.toJson())
        }
    }

    @MainActor
    @objc public static func loadFallbackPaywalls(callback: @escaping (String?, String?) -> Void) {
        Apphud.loadFallbackPaywalls(callback: { paywalls, error in
            callback(paywalls?.toJson(), error?.toMap().toJson())
        })
    }

    @MainActor
    @objc public static func setHeaders() {
        ApphudHttpClient.shared.sdkType = "unity"
        ApphudHttpClient.shared.sdkVersion = "1.1.0"
    }
    
    @MainActor
    private static func findPaywall(identifier:String, placementIdentifier: String?) async -> ApphudPaywall? {
        if(placementIdentifier != nil) {
            let placements = await Apphud.placements()
            return placements.first(where: {pl in pl.identifier == placementIdentifier})?.paywall
        }
        else {
            return await withCheckedContinuation { continuation in
                Apphud.paywallsDidLoadCallback { pwls, _ in
                    let pwl = pwls.first(where: { pw in return pw.identifier == identifier })
                    Task {
                        continuation.resume(returning: pwl)
                    }
                }
            }
        }
    }

    private static func handlePurchase(response:ApphudPurchaseResult, callback: @escaping (String) -> Void) {
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

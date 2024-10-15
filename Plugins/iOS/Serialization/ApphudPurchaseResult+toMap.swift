import ApphudSDK
import StoreKit

extension [ApphudSubscription] {
    func toJsonListOfMap() -> String {
        let list = self.map { $0.toMap() }
        do {
            let jsonData = try JSONSerialization.data(withJSONObject: list)
            if let jsonString = String(data: jsonData, encoding: .utf8) {
                return jsonString
            }
        } catch {
            return "Error converting map to JSON: \(error.localizedDescription)"
        }
        
        return "Error converting map to JSON"
    }
}

extension [ApphudNonRenewingPurchase] {
    func toJsonListOfMap() -> String {
        let list = self.map { $0.toMap() }
        do {
            let jsonData = try JSONSerialization.data(withJSONObject: list)
            if let jsonString = String(data: jsonData, encoding: .utf8) {
                return jsonString
            }
        } catch {
            return "Error converting map to JSON: \(error.localizedDescription)"
        }
        
        return "Error converting map to JSON"
    }
}

extension ApphudPurchaseResult {
    func toMap() -> [String: Any?] {
        return ["subscription" : subscription?.toMap(),
                "nonRenewingPurchase" : nonRenewingPurchase?.toMap(),
                "error": error == nil ? nil : error?.localizedDescription,
                "transaction": transaction?.toMap()
        ]
    }
}

extension ApphudSubscription {
    func toMap() -> [String: Any?] {
        return ["productId": productId,
                "expiresAt": expiresDate.timeIntervalSince1970,
                "startedAt": startedAt.timeIntervalSince1970,
                "canceledAt": canceledAt?.timeIntervalSince1970,
                "isInRetryBilling": isInRetryBilling,
                "isAutorenewEnabled": isAutorenewEnabled,
                "isIntroductoryActivated": isIntroductoryActivated,
                "isActive" : isActive(),
                "status" : status.toString()
        ]
    }
}

extension ApphudSubscriptionStatus {
    func toString() -> String {

        switch self {
        case .trial:
            return "trial"
        case .intro:
            return "intro"
        case .promo:
            return "promo"
        case .grace:
            return "grace"
        case .regular:
            return "regular"
        case .refunded:
            return "refunded"
        case .expired:
            return "expired"
        default:
            return "none"
        }
    }
}

extension ApphudNonRenewingPurchase {
    func toMap() -> [String: Any?] {
        return ["productId": productId as Any,
                "purchasedAt": purchasedAt.timeIntervalSince1970,
                "canceledAt": canceledAt?.timeIntervalSince1970,
                "isActive" : isActive()
        ]
    }
}

extension SKPaymentTransaction {
    func toMap() -> [String: Any?] {
        return ["transactionIdentifier":transactionIdentifier,
                "transactionDate":transactionDate?.timeIntervalSince1970,
                "productIdentifier": payment.productIdentifier,
                "state":transactionState.rawValue
        ]
    }
}

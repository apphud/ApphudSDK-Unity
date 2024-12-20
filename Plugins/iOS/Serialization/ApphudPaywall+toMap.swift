import ApphudSDK

extension [ApphudPaywall] {
    func toJsonListOfMap() -> String {
        let list = self.map { $0.toMap() }
        return list.toJson()
    }
}

extension ApphudPaywall {
    func toMap() -> [String: Any?] {
        return ["identifier": identifier,
                "json": json,
                "isDefault": isDefault,
                "products" : products.map({ (product:ApphudProduct) in product.toMap() }),
                "experimentName" : experimentName,
                "placementIdentifier" : placementIdentifier,
                "variationName" : variationName,
                "parentPaywallIdentifier" : parentPaywallIdentifier
        ]
    }
}

extension ApphudProduct {
    func toMap() -> [String: Any?] {
        return ["productId" : productId,
                "name" : name,
                "store" :store,
                "paywallIdentifier" : paywallIdentifier,
                "placementIdentifier" : placementIdentifier,
                "skProduct" : skProduct?.toMap()
        ]
    }
}


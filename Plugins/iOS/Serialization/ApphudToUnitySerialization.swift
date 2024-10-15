import ApphudSDK
import StoreKit

extension ApphudAttributionProvider {
    static func fromString(_ string: String) -> ApphudAttributionProvider? {
        switch string {
        case "appsFlyer":
            return .appsFlyer
        case "adjust":
            return .adjust
        case "facebook":
            return .facebook
        case "appleAdsAttribution":
            return .appleAdsAttribution
        case "firebase":
            return .firebase
        case "custom":
            return .custom
        default:
            return nil
        }
    }
}

extension Encodable {
    func toJson() -> String {
        let jsonEncoder = JSONEncoder()
        if let jsonData = try? jsonEncoder.encode(self),
           let jsonString = String(data: jsonData, encoding: .utf8) {
            return jsonString;
        } else {
            return "Failed to encode to json"
        }
    }
}

extension String {
    func toAnyFromUnityJson() -> Any? {
        guard let data = self.data(using: .utf8),
              let jsonObject = try? JSONSerialization.jsonObject(with: data, options: []),
              let dict = jsonObject as? [String: Any],
              let type = dict["type"] as? String,
              let value = dict["value"] as? String
        else {
            return nil
        }
        
        switch type {
           case "System.Int32":
               return Int(value)
           case "System.Single", "System.Double": // Assuming float and double map to these
               return Double(value)
           case "System.String":
               return value
           case "System.Boolean":
               return Bool(value)
           default:
               return nil
        }
    }
}

import Foundation
import ApphudSDK

extension [ApphudPlacement] {
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


extension ApphudPlacement {
    func toMap() -> [String: Any?] {
      var map: [String: Any?] = [
          "identifier": identifier,
          "paywall": paywall?.toMap(),
          "experimentName": experimentName,
      ]
      return map
    }
}


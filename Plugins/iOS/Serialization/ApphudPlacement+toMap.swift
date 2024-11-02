import Foundation
import ApphudSDK

extension [ApphudPlacement] {
    func toJsonListOfMap() -> String {
        let list = self.map { $0.toMap() }
        return list.toJson()
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


import StoreKit

extension Error {
    func toMap() -> [String: Any?] {
        if let skError = self as? SKError {
            return [
                "message": skError.localizedDescription,
                "errorCode": skError.errorCode,
            ]
        }else if let nsError = self as? NSError {
            return [
                "message": nsError.localizedDescription,
                "errorCode": nsError.code
            ]
        }

        return  [
            "message": localizedDescription
        ]
    }
}

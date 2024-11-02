extension [String: Any?] {
    func toJson() -> String{
        do {
            let jsonData = try JSONSerialization.data(withJSONObject: self)
            if let jsonString = String(data: jsonData, encoding: .utf8) {
                return jsonString
            }
        } catch {
            return "Error converting map to JSON: \(error.localizedDescription)"
        }
        
        return "Error converting map to JSON"
    }
}

extension [[String: Any?]] {
    func toJson() -> String{
        do {
            let jsonData = try JSONSerialization.data(withJSONObject: self)
            if let jsonString = String(data: jsonData, encoding: .utf8) {
                return jsonString
            }
        } catch {
            return "Error converting map to JSON: \(error.localizedDescription)"
        }
        
        return "Error converting map to JSON"
    }
}

using System.Collections.Generic;

namespace Apphud.Unity.Domain
{
    public abstract class SubscriptionOfferDetails
    {
        public PricingPhases PricingPhases { get; protected set; }
        public string BasePlanId { get; protected set; }
        public string OfferId { get; protected set; }
        public string OfferToken { get; protected set; }
        public List<string> OfferTags { get; protected set; }
    }
}
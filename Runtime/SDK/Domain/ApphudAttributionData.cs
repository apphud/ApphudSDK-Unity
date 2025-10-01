using System.Collections.Generic;

namespace Apphud.Unity.Domain
{
    /// <summary>
    /// Attribution data received from MMPs (e.g., AppsFlyer, Branch) or manually overridden.
    /// </summary>
    public sealed class ApphudAttributionData
    {
        /// <summary>
        /// Raw attribution data received from MMPs, such as AppsFlyer or Branch.
        /// Pass only `RawData` if no custom override logic is needed.
        /// </summary>
        public Dictionary<string, object> RawData { get; private set; }

        /// <summary>
        /// Overridden ad network responsible for user acquisition (e.g., "Meta Ads", "Google Ads").
        /// Leave null if no custom override logic is needed.
        /// </summary>
        public string AdNetwork { get; private set; }

        /// <summary>
        /// Overridden channel that drove the user acquisition (e.g., "Instagram Feed", "Google UAC").
        /// Leave null if no custom override logic is needed.
        /// </summary>
        public string Channel { get; private set; }

        /// <summary>
        /// Overridden campaign name associated with the attribution data.
        /// Leave null if no custom override logic is needed.
        /// </summary>
        public string Campaign { get; private set; }

        /// <summary>
        /// Overridden ad set name within the campaign.
        /// Leave null if no custom override logic is needed.
        /// </summary>
        public string AdSet { get; private set; }

        /// <summary>
        /// Overridden specific ad creative used in the campaign.
        /// Leave null if no custom override logic is needed.
        /// </summary>
        public string Creative { get; private set; }

        /// <summary>
        /// Overridden keyword associated with the ad campaign (if applicable).
        /// Leave null if no custom override logic is needed.
        /// </summary>
        public string Keyword { get; private set; }

        /// <summary>
        /// Custom attribution parameter for additional tracking or mapping.
        /// Use this to store extra attribution data if needed.
        /// </summary>
        public string Custom1 { get; private set; }

        /// <summary>
        /// Another custom attribution parameter for extended tracking or mapping.
        /// Use this to store extra attribution data if needed.
        /// </summary>
        public string Custom2 { get; private set; }

        public ApphudAttributionData(
            Dictionary<string, object> rawData,
            string adNetwork = null,
            string channel = null,
            string campaign = null,
            string adSet = null,
            string creative = null,
            string keyword = null,
            string custom1 = null,
            string custom2 = null
        )
        {
            RawData = rawData;
            AdNetwork = adNetwork;
            Channel = channel;
            Campaign = campaign;
            AdSet = adSet;
            Creative = creative;
            Keyword = keyword;
            Custom1 = custom1;
            Custom2 = custom2;
        }
    }
}

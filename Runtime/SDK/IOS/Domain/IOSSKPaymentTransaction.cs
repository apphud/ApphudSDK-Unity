#if UNITY_IOS

using Apphud.Unity.Domain;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSSKPaymentTransactionJson
    {
        public string transactionIdentifier;
        public long? transactionDate;
        public string productIdentifier;
        public SKPaymentTransactionState state;
    }


    internal sealed class IOSSKPaymentTransaction : SKPaymentTransaction
    {
        internal IOSSKPaymentTransaction(IOSSKPaymentTransactionJson json)
        {
            TransactionIdentifier = json.transactionIdentifier;
            TransactionDate = json.transactionDate;
            ProductIdentifier = json.productIdentifier;
            State = json.state;
        }
    }
}

#endif
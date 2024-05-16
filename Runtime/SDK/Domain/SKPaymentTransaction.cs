namespace Apphud.Unity.Domain
{
    public enum SKPaymentTransactionState
    {
        /// <summary>
        /// Transaction is being added to the server queue.
        /// </summary>
        purchasing = 0,
        /// <summary>
        /// Transaction is in queue, user has been charged.  Client should complete the transaction.
        /// </summary>
        purchased = 1,
        /// <summary>
        /// Transaction was cancelled or failed before being added to the server queue.
        /// </summary>
        failed = 2,
        /// <summary>
        /// Transaction was restored from user's purchase history.  Client should complete the transaction.
        /// </summary>
        restored = 3,
        /// <summary>
        /// The transaction is in the queue, but its final status is pending external action.
        /// </summary>
        deferred = 4
    }

    public abstract class SKPaymentTransaction
    {
        /// <summary>
        /// The unique server-provided identifier.
        /// Only valid if state is SKPaymentTransactionStatePurchased or SKPaymentTransactionStateRestored.
        /// </summary>
        public string TransactionIdentifier { get; protected set; }

        /// <summary>
        /// The date when the transaction was added to the server queue.  
        /// Only valid if state is SKPaymentTransactionStatePurchased or SKPaymentTransactionStateRestored.
        /// </summary>
        public long? TransactionDate { get; protected set; }

        /// <summary>
        /// Identifier agreed upon with the store.  Required.
        /// </summary>
        public string ProductIdentifier { get; protected set; }
        public SKPaymentTransactionState State { get; protected set; }
    }
}
using System;

namespace BalanceSheet.Store
{
    /// <summary>
    /// Thrown when a purchase of an in-app product was not successful.
    /// </summary>
    public class InAppPurchaseException : Exception
    {
        public InAppPurchaseException()
        {
        }

        public InAppPurchaseException(string message) : base(message)
        {
        }

        public InAppPurchaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
using System;

namespace BalanceSheet.Services
{
    public class AuthenticationCanceledException : Exception
    {
        public AuthenticationCanceledException()
        { }

        public AuthenticationCanceledException(string message) : base(message)
        { }

        public AuthenticationCanceledException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
using System;

namespace BalanceSheet.Services
{
    public class SignInRequiredException : Exception
    {
        public SignInRequiredException()
        { }

        public SignInRequiredException(string message) : base(message)
        { }

        public SignInRequiredException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
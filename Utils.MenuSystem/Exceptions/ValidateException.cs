using System;

namespace Utils.MenuSystem.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException()
        {
        }

        public ValidateException(string message) : base(message)
        {
        }
    }
}

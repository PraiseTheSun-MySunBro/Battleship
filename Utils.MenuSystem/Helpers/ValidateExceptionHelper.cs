using Utils.MenuSystem.Exceptions;

namespace Utils.MenuSystem.Helpers
{
    public static class ValidateExceptionHelper
    {
        public static void ThrowIfLengthIsOutOfBound(string value, int minLength, int maxLength)
        {
            if (value.Length < minLength || value.Length > maxLength)
            {
                throw new ValidateException($"{nameof(value)} length should be in range of [{minLength} .. {maxLength}]");
            }
        }
    }
}

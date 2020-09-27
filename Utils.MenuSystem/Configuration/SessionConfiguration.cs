using Utils.MenuSystem.Helpers;

namespace Utils.MenuSystem.Configuration
{
    public class SessionConfiguration
    {
        private static SessionConfiguration _config;
        private string _nickname = "NoName";

        public string Nickname
        {
            get => _nickname;
            set 
            {
                ValidateExceptionHelper.ThrowIfLengthIsOutOfBound(value, 1, 40);

                _nickname = value;
            }
        }

        public static SessionConfiguration GetInstance()
        {
            _config ??= new SessionConfiguration();
            return _config;
        }
    }
}

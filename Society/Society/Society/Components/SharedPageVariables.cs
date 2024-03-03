using Society.Shared.Models;

namespace Society.Components
{
    public class SharedPageVariables
    {
        public class SharedVariables
        {
            public static string API_URL = "http://localhost:5085/";
            public static string profileGuid = "invalid";
            public static User myUser = new User();
        }

        public class AppState
        {
            private bool _loggedIn;
            public event Action OnChange;
            public bool LoggedIn
            {
                get { return _loggedIn; }
                set
                {
                    if (_loggedIn != value)
                    {
                        _loggedIn = value;
                        NotifyStateChanged();
                    }
                }
            }

            private void NotifyStateChanged() => OnChange?.Invoke();
        }
    }
}
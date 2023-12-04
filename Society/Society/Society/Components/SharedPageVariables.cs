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
    }
}
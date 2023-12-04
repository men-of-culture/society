using Society.Shared.Models;

namespace Society.Components.Pages
{
    public class SharedPageVariables
    {
        public class SharedVariables
        {
            //string API_URL = "https://localhost:7079/";
            public static string API_URL = "http://localhost:5085/";
            public static string profileGuid = "invalid";
            public static User myUser = new User();
        }
    }
}
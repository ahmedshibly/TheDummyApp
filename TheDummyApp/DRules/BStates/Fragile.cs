using TheDummyApp.Models;

namespace TheDummyApp.Rules.Sates
{
    class Fragile
    {
        public static void CreateUser ()
        {
            var user = new User
            {
                Email = "Invalid-Email"
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDummyApp.Models;

namespace TheDummyApp.Rules
{
    class Solid
    {
        public static void CreateUser()
        {
            var user = new BetterUser
            {
                Email = new EmailAddress("some@gmail.com")
            };
        }
    }
}

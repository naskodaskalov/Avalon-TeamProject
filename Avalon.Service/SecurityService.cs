
namespace Avalon.Service
{
    using Avalon.Data;
    using Avalon.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SecurityService
    {
        private static User loggedUser;

        public static bool Login(string username, string password)
        {
            using (AvalonContext context = new AvalonContext())
            {
                if (context.Users.Any(u => u.Username == username && u.Password == password))
                {
                    loggedUser = context.Users.SingleOrDefault(u => u.Username == username);
                    return true;
                }
                return false;
            }
        }
        public static void Logout()
        {
            loggedUser = null;
        }
    }
}


namespace Avalon.Service
{
    using Avalon.Data;
    using Avalon.Models;
    using System.Linq;

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

        public static User GetLoggedUser()
        {
            return loggedUser;
        }

        public static void Logout()
        {
            loggedUser = null;
        }
    }
}

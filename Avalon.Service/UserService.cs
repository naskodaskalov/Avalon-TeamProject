
namespace Avalon.Service
{
    using Avalon.Data;
    using Avalon.Models;
    using System.Linq;

    public static class UserService
    {
        public static bool IsUserExist(string username)
        {
            using (AvalonContext context = new AvalonContext())
            {
                if (context.Users.Any(u=> u.Username.ToLower() == username))
                {
                    return true;
                }
                return false;
            }
        }
        
        public static void RegisterUser(string username, string password)
        {
            using (AvalonContext context = new AvalonContext())
            {
                User user = new User
                {
                    Username = username,
                    Password = password
                };

                context.Users.Add(user);
                context.SaveChanges();

                SecurityService.Login(username, password);
            }
        }        
    }
}

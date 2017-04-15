using Avalon.Data;
using Avalon.Models;
using System.Linq;

namespace Avalon.Service
{
    public static class CustomerService
    {
        public static void AddCustomer(string name, string address, string townName, string email, string phone, string styleName)
        {
            using (AvalonContext context = new AvalonContext())
            {
                Town town = context.Towns.FirstOrDefault(t => t.Name == townName);
                Style style = context.Styles.FirstOrDefault(s => s.Name == styleName);

                Customer customer = new Customer
                {
                    Name = name,
                    Address = address,
                    Town = town,
                    FavoriteStyle = style,
                    Email = email,
                    Phone = phone
                };
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
    }
}

using Avalon.Data;
using Avalon.Models;
using Avalon.Models.GridModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static List<string> GetAllCustomers()
        {
            using (AvalonContext context = new AvalonContext())
            {
                var customers = context.Customers.OrderBy(b => b.Name).Select(c => c.Name).ToList();

                var result = new List<string>();
                foreach (var c in customers)
                {
                    result.Add(c);
                }
                return result;
            }
        }
    }
}

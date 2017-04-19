using Avalon.Data;
using Avalon.Models;
using Avalon.Models.GridModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

        public static ObservableCollection<Customer> GetAllClients()
        {
            using (AvalonContext context = new AvalonContext())
            {
                var customers = context.Customers.ToList();

                var result = new ObservableCollection<Customer>();
                foreach (var c in customers)
                {
                    result.Add(c);
                }
                return result;
            }
        }

        public static List<string> GetAllCustomers()
        {
            using (AvalonContext context = new AvalonContext())
            {
                return context.Customers.Select(x => x.Name).ToList();
            }
        }

        public static void UpdateClient(Customer client)
        {
            using(var db = new AvalonContext())
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteClient(string clientName)
        {
            using(var db = new AvalonContext())
            {
                var client = db.Customers.FirstOrDefault(x => x.Name == clientName);
                if(client != null)
                {
                    db.Customers.Remove(client);
                    db.SaveChanges();
                }
            }
        }

        public static ObservableCollection<Customer> GetCustomersByName(string name)
        {
            using (AvalonContext context = new AvalonContext())
            {
                var clients = context.Customers.ToList();

                var result = new ObservableCollection<Customer>();
                foreach (var client in clients)
                {
                    result.Add(client);
                }
                return result;
            }
        }
    }
}

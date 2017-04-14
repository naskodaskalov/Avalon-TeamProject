
namespace Avalon.Service
{
    using Data;
    using Models;
    using System;
    using System.Linq;

    public static class BeerService
    {
        public static void SellBeer(string customerName, string beerName, string quantityStr, string priceStr)
        {
            using (var context = new AvalonContext())
            {
                decimal price = 0;
                int quantity = 0;
                var customer = context.Customers.FirstOrDefault(x => x.Name == customerName);
                var beer = context.Beers.FirstOrDefault(x => x.Name == beerName);

                if (customer == null)
                {
                    Console.WriteLine("Customer doesn't exist.");
                    return;
                }

                if (beer == null)
                {
                    Console.WriteLine("Beer doesn't exist.");
                    return;
                }

                try
                {
                    quantity = int.Parse(quantityStr);
                    price = decimal.Parse(priceStr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                if (quantity <= 0 || price <= 0)
                {
                    Console.WriteLine("Quantity or price cannot be 0 or negative.");
                    return;
                }

                var seller = context.Users.FirstOrDefault(x => x.Username == SecurityService.GetLoggedInUser().Username);

                var beers = context.Users
                    .FirstOrDefault(x => x.Username == seller.Username)
                    .Beers
                    .Where(b => b.Name == beerName)
                    .Take(quantity)
                    .ToList();

                // TODO: Check if there are enough beers for the sale if it's need...

                // Remove beers from seller 
                foreach (var beerObj in beers)
                {
                    context.Users
                        .FirstOrDefault(x => x.Username == SecurityService.GetLoggedInUser().Username)
                        .Beers.Remove(beerObj);
                }

                // Add beers to the customer
                context.Customers
                    .FirstOrDefault(x => x.Name == customerName)
                    .Beers
                    .ToList().AddRange(beers);

                var sale = new Sale
                {
                    Beers = beers,
                    Customer = customer,
                    Seller = seller,
                    Date = DateTime.Now
                };

                context.Sales.Add(sale);
                context.SaveChanges();
            }
        }
    }
}

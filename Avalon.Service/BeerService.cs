
namespace Avalon.Service
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class BeerService
    {
        public static void SellBeers(string customerName, string beerName, string quantityStr, string priceStr)
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

                var seller = context.Users.FirstOrDefault(x => x.Username == SecurityService.GetLoggedUser().Username);

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
                        .FirstOrDefault(x => x.Username == SecurityService.GetLoggedUser().Username)
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

        public static void BuyBeers(string brandName, string quantityStr, string priceStr)
        {
            using(var context = new AvalonContext())
            {
                int quantity = 0;
                decimal price = 0;
                var beerProducer = context.Breweries
                                            .FirstOrDefault(x => x.Name == brandName);

                if(beerProducer == null)
                {
                    Console.WriteLine("Invalid beer producer!");
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
                    Console.WriteLine("Quantity and price have to be numbers.");
                    return;
                }

                if (price <= 0 || quantity <= 0)
                {
                    Console.WriteLine("Price and quantity cannot be 0 or negative.");
                    return;
                }

                var beers = context.Breweries
                                    .FirstOrDefault(x => x.Name == brandName)
                                    .Beers
                                    .Take(quantity)
                                    .ToList();

                // TODO : sale..

                foreach (var beer in beers)
                {
                    context.Breweries.FirstOrDefault(x => x.Name == brandName).Beers.Remove(beer);
                }

                context.Users
                    .FirstOrDefault(x => x.Username == SecurityService.GetLoggedUser().Username)
                    .Beers.ToList().AddRange(beers);

                context.SaveChanges();
            }
        }

        // Add Beers to Brewery
        public static void AddBeers(string breweryName, string beerName, string beersCountStr)
        {
            using(var context = new AvalonContext())
            {
                var brewery = context.Breweries.FirstOrDefault(x => x.Name == breweryName);
                var beer = context.Beers.FirstOrDefault(x => x.Name == beerName);
                int beersCount;
                var beersList = new List<Beer>();

                if(brewery == null)
                {
                    Console.WriteLine("Invalid brewery.");
                    return;
                }

                if(beer == null)
                {
                    Console.WriteLine("Invalid beer name.");
                    return;
                }

                if(!int.TryParse(beersCountStr, out beersCount))
                {
                    Console.WriteLine("Beers count isn't number!");
                    return;
                }

                for (int i = 0; i < beersCount; i++)
                {
                    beersList.Add(beer);
                }

                context.Breweries.FirstOrDefault(x => x.Name == breweryName).Beers.ToList().AddRange(beersList);
                context.Beers.AddRange(beersList);
                context.SaveChanges();
            }
        }


    }
}

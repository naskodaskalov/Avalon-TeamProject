
namespace Avalon.Service
{
    using Data;
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using Models.GridModels;
    using System.Data.Entity;

    public static class BeerService
    {
        public static bool BeerExist(string beerName)
        {
            using(var db = new AvalonContext())
            {
                var isBeerExist = db.Beers.Any(b => b.Name == beerName);
                if (isBeerExist)
                {
                    return true;
                }
                return false;
            }
        }

        public static int BeerCount(string beerName)
        {
            using(var db = new AvalonContext())
            {
                return db.Beers.Where(x => x.Name == beerName).Count();
            }
        }

        public static void DeleteBeer(string beerName)
        {
       
            using (AvalonContext context = new AvalonContext())
            {
                var beer = context.Beers.Where(b => b.Name == beerName).FirstOrDefault();
                context.Beers.Remove(beer);
                context.SaveChanges();                
            }
        }

    

        //public static void SellBeers(string customerName, string beerName, string quantityStr, string priceStr)
        //{
        //    using (var context = new AvalonContext())
        //    {
        //        decimal price = 0;
        //        int quantity = 0;
        //        var customer = context.Customers.FirstOrDefault(x => x.Name == customerName);
        //        var beer = context.Beers.FirstOrDefault(x => x.Name == beerName);

        //        if (customer == null)
        //        {
        //            Console.WriteLine("Customer doesn't exist.");
        //            return;
        //        }

        //        if (beer == null)
        //        {
        //            Console.WriteLine("Beer doesn't exist.");
        //            return;
        //        }

        //        try
        //        {
        //            quantity = int.Parse(quantityStr);
        //            price = decimal.Parse(priceStr);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            return;
        //        }

        //        if (quantity <= 0 || price <= 0)
        //        {
        //            Console.WriteLine("Quantity or price cannot be 0 or negative.");
        //            return;
        //        }

        //        var seller = context.Users.FirstOrDefault(x => x.Username == SecurityService.GetLoggedUser().Username);

        //        var beers = context.Users
        //            .FirstOrDefault(x => x.Username == seller.Username)
        //            .Beers
        //            .Where(b => b.Name == beerName)
        //            .Take(quantity)
        //            .ToList();

        //        // TODO: Check if there are enough beers for the sale if it's need...

        //        // Remove beers from seller 
        //        foreach (var beerObj in beers)
        //        {
        //            context.Users
        //                .FirstOrDefault(x => x.Username == SecurityService.GetLoggedUser().Username)
        //                .Beers.Remove(beerObj);
        //        }

        //        // Add beers to the customer
        //        context.Customers
        //            .FirstOrDefault(x => x.Name == customerName)
        //            .Beers
        //            .ToList().AddRange(beers);

        //        var sale = new Sale
        //        {
        //            Beers = beers,
        //            Customer = customer,
        //            Seller = seller,
        //            Date = DateTime.Now
        //        };

        //        context.Sales.Add(sale);
        //        context.SaveChanges();
        //    }
        //}

        //public static void BuyBeers(string brandName, string quantityStr, string priceStr)
        //{
        //    using (var context = new AvalonContext())
        //    {
        //        int quantity = 0;
        //        decimal price = 0;
        //        var beerProducer = context.Breweries
        //                                    .FirstOrDefault(x => x.Name == brandName);

        //        if (beerProducer == null)
        //        {
        //            Console.WriteLine("Invalid beer producer!");
        //            return;
        //        }

        //        try
        //        {
        //            quantity = int.Parse(quantityStr);
        //            price = decimal.Parse(priceStr);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            Console.WriteLine("Quantity and price have to be numbers.");
        //            return;
        //        }

        //        if (price <= 0 || quantity <= 0)
        //        {
        //            Console.WriteLine("Price and quantity cannot be 0 or negative.");
        //            return;
        //        }

        //        var beers = context.Breweries
        //                            .FirstOrDefault(x => x.Name == brandName)
        //                            .Beers
        //                            .Take(quantity)
        //                            .ToList();

        //        // TODO : sale..

        //        foreach (var beer in beers)
        //        {
        //            context.Breweries.FirstOrDefault(x => x.Name == brandName).Beers.Remove(beer);
        //        }

        //        context.Users
        //            .FirstOrDefault(x => x.Username == SecurityService.GetLoggedUser().Username)
        //            .Beers.ToList().AddRange(beers);

        //        context.SaveChanges();
        //    }
        //}

        public static ObservableCollection<string> GetAllBeerStyles()
        {
            using (AvalonContext context = new AvalonContext())
            {
                ObservableCollection<string> result = new ObservableCollection<string>();

                var styles = context.Styles.OrderBy(s => s.Name).ToList();

                result.Add("Select styles");
                foreach (var style in styles)
                {
                    result.Add(style.Name);
                }
                return result;
            }
        }
       
        public static ObservableCollection<BreweryGrid> GetAllBreweries()
        {
            using (AvalonContext context = new AvalonContext())
            {
                var breweries = context.Breweries.OrderBy(b => b.Name).ToList();

                ObservableCollection<BreweryGrid> result = new ObservableCollection<BreweryGrid>();
                foreach (var brew in breweries)
                {
                    BreweryGrid brewGrid = new BreweryGrid()
                    {
                        Name = brew.Name,
                        Town = brew.Town.Name,
                        Address = brew.Adress
                    };
                    result.Add(brewGrid);
                }
                return result;
            }
        }

        public static ObservableCollection<string> GetAllBreweriesNames()
        {
            using (AvalonContext context = new AvalonContext())
            {
                var breweries = context.Breweries.OrderBy(b => b.Name).Select(b => b.Name).ToList();

                ObservableCollection<string> result = new ObservableCollection<string>();
                foreach (var brew in breweries)
                {
                   
                    result.Add(brew);
                }
                return result;
            }
        }

        public static ObservableCollection<SalesGrid> ShowAllSales()
        {
            using (AvalonContext context = new AvalonContext())
            {
                var sales = context.Sales.Select(s => new
                {
                    Id = s.Id,
                    Date = s.Date,
                    Customer = s.Customer.Name,
                    BeersCount = s.Beers.Select(b => b.Quantity).ToList(),
                    TotalPrice = s.Beers.Select(b=> new { BeerPrice = b.Beer.SalePrice , Quantity = b.Quantity }).ToList(),
                    Seller = s.Seller.Username
                });
                ObservableCollection<SalesGrid> result = new ObservableCollection<SalesGrid>();

                foreach (var sale in sales)
                {
                    SalesGrid saleGrid = new SalesGrid
                    {
                        SaleId = sale.Id,
                        Date = sale.Date,
                        Customer = sale.Customer,
                        Seller = sale.Seller
                    };

                    int beerCount = 0;
                    decimal totalPrice = 0;
                    foreach (var q in sale.BeersCount)
                    {
                        beerCount += q;
                    }

                    foreach (var b in sale.TotalPrice)
                    {
                        totalPrice += b.BeerPrice * b.Quantity;
                    }
                    saleGrid.TotalPrice = totalPrice;
                    saleGrid.BeersCount = beerCount;
                    result.Add(saleGrid);
                }
                return result;
            }
        }

        public static void AddSale(Dictionary<string,int> beers , string customerName)
        {
            using (AvalonContext context = new AvalonContext())
            {
                var customer = context.Customers
                    .Where(c=> c.Name.ToLower() == customerName.ToLower()).First();

                Sale sale = new Sale
                {
                    Date = DateTime.Now,
                    Customer = customer,
                    SellerId = SecurityService.GetLoggedUser().Id
                };
                context.Sales.Add(sale);

                foreach (var b in beers)
                {
                    string beerName = b.Key;
                    int quantity = b.Value;
                    var beer = context.Beers.Where(be => be.Name.ToLower() == beerName.ToLower()).First();
                    beer.Quantity -= quantity;

                    BeerSale beerSale = new BeerSale
                    {
                        Beer = beer,
                        Quantity = quantity,
                        Sale = sale
                    };
                    sale.Beers.Add(beerSale);
                }
                context.SaveChanges();
            }
        }



        // Add Beers to Brewery
        //public static void AddBeers(string breweryName, string beerName, string beersCountStr)
        //{
        //    using(var context = new AvalonContext())
        //    {
        //        var brewery = context.Breweries.FirstOrDefault(x => x.Name == breweryName);
        //        var beer = context.Beers.FirstOrDefault(x => x.Name == beerName);
        //        int beersCount;
        //        var beersList = new List<Beer>();

        //        if(brewery == null)
        //        {
        //            Console.WriteLine("Invalid brewery.");
        //            return;
        //        }

        //        if(beer == null)
        //        {
        //            Console.WriteLine("Invalid beer name.");
        //            return;
        //        }

        //        if(!int.TryParse(beersCountStr, out beersCount))
        //        {
        //            Console.WriteLine("Beers count isn't number!");
        //            return;
        //        }

        //        for (int i = 0; i < beersCount; i++)
        //        {
        //            beersList.Add(beer);
        //        }

        //        context.Breweries.FirstOrDefault(x => x.Name == breweryName).Beers.ToList().AddRange(beersList);
        //        context.Beers.AddRange(beersList);
        //        context.SaveChanges();
        //    }
        //}

        public static ObservableCollection<Beer> GetAllBeers()
        {
            using (AvalonContext context = new AvalonContext())
            {
                var beers = context.Beers.Include("Style").Include("Brewery").Include("Distributor").OrderBy(b => b.Name).ToList();

                var result = new ObservableCollection<Beer>();
                foreach (var beer in beers)
                {
                    result.Add(beer);
                }
                return result;
            }
        }

        public static void AddBrewery(Brewery brewery, string chosenTown, List<string> chosenBeers, List<string> chosenDistributors)
        {
            using (var context = new AvalonContext())
            {
                var town = context.Towns.Where(t => t.Name == chosenTown).FirstOrDefault();

                brewery.Town = town;

                foreach (var chosenBeer in chosenBeers)
                {
                    var beer = context.Beers.Where(b => b.Name == chosenBeer).FirstOrDefault();
                    brewery.Beers.Add(beer);
                }

                foreach (var chosenDistributor in chosenDistributors)
                {
                    var distro = context.Distributors.Where(b => b.Name == chosenDistributor).FirstOrDefault();
                    brewery.Distributors.Add(distro);
                }


                context.Breweries.Add(brewery);
                context.SaveChanges();
            }
        }

        public static ObservableCollection<Beer> GetBeersByName(string name)
        {
            using (AvalonContext context = new AvalonContext())
            {
                var beers = context.Beers.Where(b => b.Name.Contains(name)).OrderBy(b => b.Name).ToList();

                var result = new ObservableCollection<Beer>();
                foreach (var beer in beers)
                {
                    result.Add(beer);
                }
                return result;
            }
        }

        public static void UpdateBeer(Beer beerToUpdate, string newstyle, string newdistributor, string newbrewery)
        {
            using (AvalonContext context = new AvalonContext())
            {
                if (newstyle != String.Empty)
                {
                    Style newStyle = context.Styles.Where(s => s.Name == newstyle).Include("Beers").FirstOrDefault();
                    beerToUpdate.Style = newStyle;
                    beerToUpdate.StyleId = newStyle.Id;
                }
                if (newdistributor != String.Empty)
                {
                    Distributor newDistributor = context.Distributors.Where(s => s.Name == newdistributor).Include("Breweries").Include("Beers").FirstOrDefault();
                    beerToUpdate.Distributor = newDistributor;
                    beerToUpdate.DistributorId = newDistributor.Id;
                }
                if (newbrewery != String.Empty)
                {
                    Brewery newBrewery = context.Breweries.Where(s => s.Name == newbrewery).Include("Beers").Include("Distributors").FirstOrDefault();
                    beerToUpdate.Brewery = newBrewery;
                    beerToUpdate.BreweryId = newBrewery.Id;
                }

                

                context.Beers.Attach(beerToUpdate);
                //context.Entry(beerToUpdate).Reference(o => o.Style).Load();
                //context.Entry(beerToUpdate).Reference(o => o.Brewery).Load();
                //context.Entry(beerToUpdate).Reference(o => o.Distributor).Load();

                context.Entry(beerToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

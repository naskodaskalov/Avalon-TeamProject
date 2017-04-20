
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
                result.Add("Select brewery");
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
                    TotalSalePrice = s.Beers.Select(b => new { BeerPrice = b.Beer.SalePrice, Quantity = b.Quantity }).ToList(),
                    TotalBoughtPrice = s.Beers.Select(b => new { BeerPrice = b.Beer.DistributorPrice, Quantity = b.Quantity }).ToList(),
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
                    decimal salePrice = 0;
                    decimal boughtPrice = 0;

                    foreach (var q in sale.BeersCount)
                    {
                        beerCount += q;
                    }

                    foreach (var b in sale.TotalSalePrice)
                    {
                        salePrice += (decimal)(b.BeerPrice * b.Quantity);
                    }

                    foreach (var b in sale.TotalBoughtPrice)
                    {
                        boughtPrice += (decimal)(b.BeerPrice * b.Quantity);
                    }
                    var profit = salePrice - boughtPrice;

                    saleGrid.TotalBoughtPrice = boughtPrice;
                    saleGrid.Profit = profit;
                    saleGrid.TotalSalePrice = salePrice;
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

       

        public static void AddBeer(string beerName, decimal salePrice, int quantity, float rating, string styleName, string breweryName, string distributorName, decimal distributorPrice)
        {
            using (AvalonContext context = new AvalonContext())
            {
                Style style = context.Styles.FirstOrDefault(s => s.Name.ToLower() == styleName.ToLower());
                Brewery brewery = context.Breweries.FirstOrDefault(b => b.Name.ToLower() == breweryName.ToLower());
                Distributor distrbutor = context.Distributors.FirstOrDefault(d => d.Name.ToLower() == distributorName.ToLower());
                Beer beer = new Beer
                {
                    Name = beerName,
                    SalePrice = salePrice,
                    Quantity = quantity,
                    Rating = rating,
                    Style = style,
                    Brewery = brewery,
                    Distributor = distrbutor,
                    DistributorPrice = distributorPrice
                };
                context.Beers.Add(beer);
                context.SaveChanges();
                
            }
        }

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


        public static ObservableCollection<string> GetAllDistributors()
        {
            using (AvalonContext context = new AvalonContext())
            {
                var distributorNames = context.Distributors.OrderBy(d => d.Name).Select(d => d.Name);

                var result = new ObservableCollection<string>();
                result.Add("Select distributor");
                foreach (var distributor in distributorNames)
                {
                    result.Add(distributor);
                }
                return result;
            }
        }

        public static void UpdateBeer(Beer beerToUpdate, string newstyle, string newdistributor, string newbrewery)
        {
            using (AvalonContext context = new AvalonContext())
            {
                context.Beers.Attach(beerToUpdate);

                context.Entry(beerToUpdate).Reference(o => o.Style).Load();
                context.Entry(beerToUpdate).Reference(o => o.Brewery).Load();
                context.Entry(beerToUpdate).Reference(o => o.Distributor).Load();

                
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

                context.Entry(beerToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

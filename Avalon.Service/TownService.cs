using Avalon.Data;
using Avalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalon.Service
{
    public static class TownService
    {
        //public static List<Brewery> GetBreweries ()
        //{

        //    //to do 
            
        //}

        public static void AddTown(string townName, string zipCode, string countryName, string continentName)
        {
            using (var context = new AvalonContext())
            {
                var country = context.Countries.FirstOrDefault(x => x.Name == countryName);
                if(country == null)
                {
                    country = new Country
                    {
                        Name = countryName
                    };

                    context.SaveChanges();
                }

                var newTown = new Town()
                {
                    Name = townName,
                    Country = country,
                    ZipCode = zipCode.ToString()
                };

                context.Towns.Add(newTown);
                context.SaveChanges();
            }
        }

    }
}

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

        public static void AddTown(string townName, string zipCode )
        {
            var newTown = new Town()
            {
                Name = townName
            };

            using (var context = new AvalonContext())
            {
                context.Towns.Add(newTown);
                context.SaveChanges();
            }
        }

    }
}

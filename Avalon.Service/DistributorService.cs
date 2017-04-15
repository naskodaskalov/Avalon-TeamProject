using Avalon.Data;
using Avalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalon.Service
{
    public static class DistributorService
    {



        public static void AddDistributor(Distributor distributor, string chosenTown, List<string> chosenBreweries)
        {


            using (var context = new AvalonContext())
            {
                var town = context.Towns.Where(t => t.Name == chosenTown).FirstOrDefault();

                distributor.Town = town;

                foreach (var brew in chosenBreweries)
                {
                    var brewery = context.Breweries.Where(b => b.Name == brew).FirstOrDefault();
                    distributor.Breweries.Add(brewery);
                }

                context.Distributors.Add(distributor);
                context.SaveChanges();
            }
        }

    }
}

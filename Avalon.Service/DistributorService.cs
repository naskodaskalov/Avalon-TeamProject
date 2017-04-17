using Avalon.Data;
using Avalon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

        public static ObservableCollection<Distributor> GetAllDistributors()
        {
            using (AvalonContext context = new AvalonContext())
            {
                var distros = context.Distributors.Include("Town").Include("Breweries").OrderBy(b => b.Name).ToList();

                var result = new ObservableCollection<Distributor>();
                foreach (var d in distros)
                {
                    result.Add(d);
                }
                return result;
            }
        }

        public static ObservableCollection<string> GetAllDistributorsNames()
        {
            using (AvalonContext context = new AvalonContext())
            {
                var distros = context.Distributors.Include("Town").Include("Breweries").OrderBy(b => b.Name).Select(d => d.Name).ToList();

                var result = new ObservableCollection<string>();
                foreach (var d in distros)
                {
                    result.Add(d);
                }
                return result;
            }
        }

        public static void DeleteDistributor(string distributorName)
        {

            using (AvalonContext context = new AvalonContext())
            {
                var distributorToDelete = context.Distributors.Where(b => b.Name == distributorName).FirstOrDefault();
                context.Distributors.Remove(distributorToDelete);
                context.SaveChanges();
            }
        }

        public static void UpdateDistributor(Distributor distributorToUpdate, string newTown, List<string> _checkedBreweries)
        {
            using (AvalonContext context = new AvalonContext())
            {

                context.Distributors.Attach(distributorToUpdate);

                context.Entry(distributorToUpdate).Reference(o => o.Town).Load();
                context.Entry(distributorToUpdate).Collection(o => o.Breweries).Load();


                if (newTown != String.Empty)
                {
                    Town town = context.Towns.Where(s => s.Name == newTown).FirstOrDefault();
                    distributorToUpdate.Town = town;
                    distributorToUpdate.TownId = town.Id;
                }

                if (_checkedBreweries.Count != 0)
                {
                    foreach (var item in context.Distributors.Where(d => d.Name == distributorToUpdate.Name).FirstOrDefault().Breweries.ToList())
                    {
                        distributorToUpdate.Breweries.Remove(item);
                    }


                    foreach (var br in _checkedBreweries)
                    {
                        var brewery = context.Breweries.Where(b => b.Name == br).FirstOrDefault();
                        distributorToUpdate.Breweries.Add(brewery);

                    }
                    
                }

                context.Entry(distributorToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static ObservableCollection<Distributor> GetDistributorsByName(string name)
        {
            using (AvalonContext context = new AvalonContext())
            {
                var distributors = context.Distributors.Where(b => b.Name.Contains(name)).OrderBy(b => b.Name).ToList();

                var result = new ObservableCollection<Distributor>();
                foreach (var d in distributors)
                {
                    result.Add(d);
                }
                return result;
            }
        }


    }
}

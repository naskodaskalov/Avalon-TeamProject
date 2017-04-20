namespace Avalon.Service
{
    using Avalon.Data;
    using Avalon.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
                Distributor distributorToDelete = context.Distributors
                    .FirstOrDefault(b => b.Name.ToLower() == distributorName.ToLower());
                distributorToDelete.Breweries.Clear();
                distributorToDelete.Town = null;
                distributorToDelete.Beers.Clear();

                context.Distributors.Remove(distributorToDelete);
                context.SaveChanges();
            }
        }

        public static void UpdateDistributor(string distributorToUpdateName,string newName, string town,string phone,string address, List<string> breweries)
        {
            using (AvalonContext context = new AvalonContext())
            {
                Town newTown = context.Towns.FirstOrDefault(t => t.Name.ToLower() == town.ToLower());

                Distributor distributor = context.Distributors
                    .FirstOrDefault(d => d.Name.ToLower() == distributorToUpdateName.ToLower());
                distributor.Breweries.Clear();
                distributor.Name = newName;
                distributor.Town = newTown;
                distributor.Phone = phone;
                distributor.Address = address;

                foreach (var brew in breweries)
                {
                    distributor.Breweries.Add(context.Breweries.FirstOrDefault(b => b.Name.ToLower() == brew.ToLower()));
                }
                
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

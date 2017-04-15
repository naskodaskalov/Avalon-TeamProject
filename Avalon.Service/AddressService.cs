
namespace Avalon.Service
{
    using Data;
    using Models;
    using System.Collections.ObjectModel;
    using System.Linq;

    public static class AddressService
    {
        public static ObservableCollection<string> GetAllTowns()
        {
            using (AvalonContext context = new AvalonContext())
            {
                ObservableCollection<string> result = new ObservableCollection<string>();

                var towns = context.Towns.OrderBy(t=> t.Name).ToList();
                result.Add("Select towns");

                foreach (var town in towns)
                {
                    result.Add(town.Name);
                }
                return result;
            }
        }

        public static bool IsTownExisiting(string townName, string countryName)
        {
            using (AvalonContext context = new AvalonContext())
            {
                if (context.Towns.Any(t=> t.Name.ToLower() == townName.ToLower() && t.Country.Name.ToLower() == countryName.ToLower()))
                {
                    return true;
                }
                return false;
            }
        }

        //public static void AddTown(string name, string zipcode, string countryName, string continent)
        //{
        //    using (AvalonContext context = new AvalonContext())
        //    {
        //        Country country = context.Countries.FirstOrDefault(c => c.Name.ToLower() == countryName.ToLower());

        //        if (country == null)
        //        {
        //            country.Name = name;
        //            country.Continent = continent;
        //        }

        //        Town town = new Town
        //        {
        //            Name = name,
        //            ZipCode = zipcode,
        //            Country = country

        //        };
        //        context.Towns.Add(town);
        //        context.SaveChanges();
        //    }
        //}
    }
}

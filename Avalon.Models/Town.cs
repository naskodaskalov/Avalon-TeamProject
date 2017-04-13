
namespace Avalon.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public Town()
        {
            this.Breweries = new HashSet<Brewery>();
            this.Distributors = new HashSet<Distributor>();
            this.Styles = new HashSet<Style>();
            this.Customers = new HashSet<Customer>();
        }
        public int Id { get; set; }

        public string ZipCode { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Brewery> Breweries { get; set; }

        public virtual ICollection<Distributor> Distributors { get; set; }

        public virtual ICollection<Style> Styles { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

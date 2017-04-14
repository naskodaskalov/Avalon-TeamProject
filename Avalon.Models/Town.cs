
namespace Avalon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public Town()
        {
            this.Breweries = new HashSet<Brewery>();
            this.Distributors = new HashSet<Distributor>();
            this.Customers = new HashSet<Customer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ZipCode { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Brewery> Breweries { get; set; }

        public virtual ICollection<Distributor> Distributors { get; set; }
        
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

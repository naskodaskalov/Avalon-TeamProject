
namespace Avalon.Models
{
    using System.Collections.Generic;

    public class Style
    {
        public Style()
        {
            this.Beers = new HashSet<Beer>();
            this.Customers = new HashSet<Customer>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int? OriginId { get; set; }

        public virtual Town Origin { get; set; }

        public float ServingTemp { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

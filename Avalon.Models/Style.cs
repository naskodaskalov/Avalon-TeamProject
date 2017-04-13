
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

        public virtual Country Origin { get; set; }

        public string ServingTemp { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

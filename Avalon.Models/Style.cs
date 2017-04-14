
namespace Avalon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Style
    {
        public Style()
        {
            this.Beers = new HashSet<Beer>();
            this.Customers = new HashSet<Customer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? OriginId { get; set; }

        public virtual Country Origin { get; set; }

        public string ServingTemp { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

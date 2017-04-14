
namespace Avalon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        public Sale()
        {
            this.Beers = new HashSet<Beer>();
        }
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public int? CustomerId { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        public int? SellerId { get; set; }

        [Required]
        public virtual User Seller { get; set; }
    }
}

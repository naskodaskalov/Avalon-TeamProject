
namespace Avalon.Models
{
    using System;
    using System.Collections.Generic;

    public class Sale
    {
        public Sale()
        {
            this.Beers = new HashSet<BeerSale>();
        }
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<BeerSale> Beers { get; set; }

        public int? SellerId { get; set; }

        public virtual User Seller { get; set; }
    }
}

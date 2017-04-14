
namespace Avalon.Models
{
    using System.Collections.Generic;

    public class Beer
    {
        public Beer()
        {
            this.Sales = new HashSet<Sale>();
            this.Awards = new HashSet<Award>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public float Rating { get; set; }

        public int? StyleId { get; set; }

        public virtual Style Style { get; set; }
        public int? BreweryId { get; set; }

        public virtual Brewery Brewery { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public virtual ICollection<Award> Awards { get; set; }

    }
}

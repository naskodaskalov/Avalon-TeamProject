
namespace Avalon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Beer
    {
        public Beer()
        {
            this.Sales = new HashSet<BeerSale>();
            this.Awards = new HashSet<Award>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        public int Quantity { get; set; }

        public float Rating { get; set; }

        public int? StyleId { get; set; }

        public virtual Style Style { get; set; }
        public int? BreweryId { get; set; }

        public virtual Brewery Brewery { get; set; }

        public virtual ICollection<BeerSale> Sales { get; set; }

        public virtual ICollection<Award> Awards { get; set; }

        public decimal? DistributorPrice { get; set; }

        public int? DistributorId { get; set; }
        
        public virtual Distributor Distributor { get; set; }

    }
}

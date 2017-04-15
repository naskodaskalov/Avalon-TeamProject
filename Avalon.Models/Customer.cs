using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avalon.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
            this.Beers = new HashSet<Beer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? FavoriteStyleId { get; set; }

        public virtual Style FavoriteStyle { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }
    }
}

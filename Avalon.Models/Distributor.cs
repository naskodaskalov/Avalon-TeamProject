
namespace Avalon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Distributor
    {
        public Distributor()
        {
            this.Breweries = new HashSet<Brewery>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Brewery> Breweries { get; set; }

    }
}

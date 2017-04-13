
namespace Avalon.Models
{
    using System.Collections.Generic;

    public class Distributor
    {
        public Distributor()
        {
            this.Breweries = new HashSet<Brewery>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Brewery> Breweries { get; set; }

    }
}

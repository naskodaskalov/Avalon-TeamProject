
namespace Avalon.Models
{
    using System.Collections.Generic;

    public class Brewery
    {
        public Brewery()
        {
            this.Beers = new HashSet<Beer>();
            this.Distributors = new HashSet<Distributor>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        public virtual ICollection<Distributor> Distributors { get; set; }
    }
}

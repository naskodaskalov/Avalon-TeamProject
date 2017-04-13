
namespace Avalon.Models
{
    using System.Collections.Generic;

    public class Award
    {
        public Award()
        {
            this.Beers = new HashSet<Beer>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Year { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }
    }
}

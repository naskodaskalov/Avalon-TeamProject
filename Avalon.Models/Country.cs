
namespace Avalon.Models
{
    using System.Collections.Generic;

    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Continent { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}

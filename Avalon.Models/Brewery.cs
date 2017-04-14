
namespace Avalon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Brewery
    {
        public Brewery()
        {
            this.Beers = new HashSet<Beer>();
            this.Distributors = new HashSet<Distributor>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Adress { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }

        public virtual ICollection<Distributor> Distributors { get; set; }
    }
}

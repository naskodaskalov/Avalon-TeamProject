
namespace Avalon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Award
    {
        public Award()
        {
            this.Beers = new HashSet<Beer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Year { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }
    }
}


namespace Avalon.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Sales = new HashSet<Sale>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}

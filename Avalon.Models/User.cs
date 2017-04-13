
namespace Avalon.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}

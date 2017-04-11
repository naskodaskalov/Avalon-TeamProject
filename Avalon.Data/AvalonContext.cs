namespace Avalon.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AvalonContext : DbContext
    {
      
        public AvalonContext()
            : base("name=AvalonContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }


}
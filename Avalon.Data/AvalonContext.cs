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

        public virtual DbSet<Award> Awards { get; set; }

        public virtual DbSet<Beer> Beers { get; set; }

        public virtual DbSet<BeerSale> BeerSales { get; set; }

        public virtual DbSet<Brewery> Breweries { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Distributor> Distributors { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Style> Styles { get; set; }

        public virtual DbSet<Town> Towns { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerSale>()
               .HasKey(bs => new { bs.BeerId, bs.SaleId });

            modelBuilder.Entity<BeerSale>()
                .HasRequired(bs => bs.Beer)
                .WithMany(b => b.Sales)
                .HasForeignKey(bs => bs.BeerId);

            modelBuilder.Entity<BeerSale>()
                .HasRequired(bs => bs.Sale).WithMany(s => s.Beers)
                .HasForeignKey(bs => bs.SaleId);

            modelBuilder.Entity<Brewery>()
                .HasMany(b => b.Distributors)
                .WithMany(d => d.Breweries)
                .Map(bd =>
                {
                    bd.ToTable("BreweryDistributors");
                    bd.MapLeftKey("BreweryId");
                    bd.MapRightKey("DistributorId");
                });

            modelBuilder.Entity<Award>()
                .HasMany(a => a.Beers)
                .WithMany(b => b.Awards)
                .Map(ab =>
                {
                    ab.ToTable("BeerAwards");
                    ab.MapLeftKey("AwardId");
                    ab.MapRightKey("BeerId");
                });
        }
    }


}
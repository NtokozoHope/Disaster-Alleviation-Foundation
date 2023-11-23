using Disaster_Alleviation_Foundation.Models;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Alleviation_Foundation.Data
{
    public class DAFContext : DbContext
    {
        public DAFContext(DbContextOptions<DAFContext> options)
        : base (options) { }

        public DbSet<GoodsDonation> GoodsDonation { get; set; }
        public DbSet<MonetaryDonation> MonetaryDonation { get; set; }
        public DbSet<Disaster> Disaster { get; set; }

        public DbSet<GoodsAllocation> GoodsAllocation { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure relationships if needed
        //    modelBuilder.Entity<Disaster>()
        //        .HasMany(d => d.MoneyAllocations)
        //        .WithOne(m => m.Disaster)
        //        .HasForeignKey(m => m.DisasterId);

        //    modelBuilder.Entity<Disaster>()
        //        .HasMany(d => d.GoodsAllocations)
        //        .WithOne(g => g.Disaster)
        //        .HasForeignKey(g => g.DisasterId);
        //}
    }
}

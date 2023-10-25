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
        public DbSet<Disaster> Disasters { get; set; }
    }
}

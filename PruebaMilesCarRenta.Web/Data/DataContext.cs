using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaMilesCarRenta.Shared.Entities;

namespace PruebaMilesCarRenta.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Vehicle> VEHICLE { get; set; }
        public DbSet<Preference> PREFRENCE { get; set; }
        public DbSet<Booking> BOOKING { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

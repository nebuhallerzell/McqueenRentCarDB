using Microsoft.EntityFrameworkCore;
using McqueenRentCarDB.Models;

namespace McqueenRentCarDB.Utility
{
    public class UygulamaDbContext:DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }

        public DbSet<CarBrands> Car_Brand{ get; set; }
    }
}

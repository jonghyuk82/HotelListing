using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Korea",
                    ShortName = "KR"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Jamaica",
                    ShortName = "JM"
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Bahamas",
                    ShortName = "BS"
                }

            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = Guid.NewGuid(),
                    Name = "Walker Hill",
                    Address = "Gangjin-gu",
                    Rating = 4.4,
                },
                new Hotel
                {
                    Id = Guid.NewGuid(),
                    Name = "Hilton",
                    Address = "Seoul",
                    Rating = 4,
                },
                new Hotel
                {
                    Id = Guid.NewGuid(),
                    Name = "Lotte Hotel",
                    Address = "Jamsil",
                    Rating = 5,
                }
            );
        }
    }
}

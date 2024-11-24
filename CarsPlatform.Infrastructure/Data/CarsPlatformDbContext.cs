using CarsPlatform.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarsPlatform.Infrastructure.Data
{
    public class CarsPlatformDbContext : IdentityDbContext<User, Role, int>
    {
        public CarsPlatformDbContext(DbContextOptions<CarsPlatformDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
    }
}

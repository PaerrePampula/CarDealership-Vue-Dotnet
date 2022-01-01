

using Microsoft.EntityFrameworkCore;

namespace CarDealership.Backend.Models
{
    public class CarDBContext : DbContext
    {
        public CarDBContext(DbContextOptions<CarDBContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}

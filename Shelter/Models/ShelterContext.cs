using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shelter.Models
{
  public class ShelterContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Animal> Animals { get; set; }
    public DbSet<AnimalType> Types { get; set; }

    public ShelterContext(DbContextOptions options) : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
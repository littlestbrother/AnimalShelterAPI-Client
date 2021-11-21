using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Models
{
  public class AnimalAPIContext: DbContext
  {
    public AnimalAPIContext(DbContextOptions<AnimalAPIContext> options)
      : base (options)
      {
      }

      public DbSet<Animal> Animals { get; set; }
  }
}
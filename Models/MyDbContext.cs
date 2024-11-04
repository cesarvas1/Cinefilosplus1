using Microsoft.EntityFrameworkCore;
namespace Cinefilosplus.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Cinefilosplus> Peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cinefilosplus>().HasKey(Peliculas => Peliculas.idpeliculas);
        }
    }
}
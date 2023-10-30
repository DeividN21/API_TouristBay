using API_TouristBay.Models;
using API_TouristBay.Models.Pasajeros;
using Microsoft.EntityFrameworkCore;


namespace API_TouristBay.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options) : base(options)
        { }

        public DbSet<Pasajero> Pasajero { get; set; }

        public DbSet<Vuelo> Vuelo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pasajero>().HasData(
            new Pasajero()
                
                );

            modelBuilder.Entity<Vuelo>().HasData(
            new Vuelo()

                );
        }

    }
}

using EasyStay.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyStay.Infraestructure.DataAcces
{
    public class EasyStayDbContex : IdentityDbContext<Users>
    {
        public EasyStayDbContex(DbContextOptions<EasyStayDbContex> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Hotel>().Property(e => e.Id).HasConversion<string>();
            
            modelBuilder.Entity<Room>().Property(e => e.Id).HasConversion<string>();
            modelBuilder.Entity<Room>().Property(e => e.HotelId).HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}

using EasyStay.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyStay.Infraestructure.DataAcces
{
    public class EasyStayDbContex: IdentityDbContext<Users>
    {
        public EasyStayDbContex(DbContextOptions<EasyStayDbContex> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RumahSakitWeb.Models;

namespace RumahSakitWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Dokter> ParaDokter { get; set; }
        public DbSet<Pasien> ParaPasien { get; set; }
        
        

    }
}

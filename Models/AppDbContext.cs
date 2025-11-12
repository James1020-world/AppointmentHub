using Microsoft.EntityFrameworkCore;

namespace AppointmentHubMVC.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Appointments> Appointments { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected AppDbContext()
        {
        }
    }
}

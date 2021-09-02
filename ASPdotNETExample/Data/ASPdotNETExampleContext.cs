using ASPdotNETExample.Models;

using Microsoft.EntityFrameworkCore;

namespace ASPdotNETExample.Data
{
    public class ASPdotNETExampleContext : DbContext
    {
        public ASPdotNETExampleContext(DbContextOptions<ASPdotNETExampleContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}

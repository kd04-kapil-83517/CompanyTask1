using Microsoft.EntityFrameworkCore;
using WebApplication123.Models;


namespace WebApplication123.Data
{


    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }

}

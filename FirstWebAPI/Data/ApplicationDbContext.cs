using FirstWebAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<Employee> tbl_E { get; set; }
        public DbSet<Student> tbl_S { get; set; }
      
    }
}

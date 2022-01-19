using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreInMemoryDatabaseExample.Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}

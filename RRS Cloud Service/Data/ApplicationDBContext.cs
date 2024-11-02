using Microsoft.EntityFrameworkCore;
using RRS_Cloud_Service.Models;

namespace RRS_Cloud_Service.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using MyAppCleanArchitecture.Core.Entities;

namespace MyAppCleanArchitecture.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}

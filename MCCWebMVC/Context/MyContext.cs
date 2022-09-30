using MCCWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MCCWebMVC.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Gaji> Gajis { get; set; }
        public DbSet<Jabatan> Jabatans { get; set; }
        public DbSet<CutiLibur> CutiLiburs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}

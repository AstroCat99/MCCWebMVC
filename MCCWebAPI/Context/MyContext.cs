using MCCWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MCCWebAPI.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Gaji> Gajis { get; set; }
        public DbSet<Jabatan> Jabatans { get; set; }
        public DbSet<Karyawan> Karyawans { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}

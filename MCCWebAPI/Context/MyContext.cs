﻿using MCCWebAPI.Models;
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
    }
}
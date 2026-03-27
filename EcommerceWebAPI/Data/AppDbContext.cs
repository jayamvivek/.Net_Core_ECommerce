using EcommerceWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EcommerceWebAPI.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets represent tables in the database
        public DbSet<User> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Uoms> Uoms { get; set; }
        public DbSet<UomTypes> UomTypes { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

    }
}

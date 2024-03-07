using PovilasWebProject.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PovilasWebProject.Server.Data
{
    public class PovilasDbContext : DbContext
    {
        public PovilasDbContext(DbContextOptions<PovilasDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}

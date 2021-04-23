using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testCore.Models;

namespace testCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Laptop> Laptop { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<LaptopImage> LaptopImage { get; set; }

    }
}

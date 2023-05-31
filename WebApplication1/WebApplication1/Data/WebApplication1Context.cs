using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alcohol>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18,2)");
        }


        public DbSet<WebApplication1.Models.Alcohol> Alcohol { get; set; } = default!;
    }
}

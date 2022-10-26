using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ClimaContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Climate> Climates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Climate>()
                .HasKey(c => c.IdClima);

            modelBuilder.Entity<Temp>()
                .HasOne(c => c.Climate)
                .WithMany(t => t.Temp)
                .HasForeignKey(c => c.IdClima);

        }
    }
    
}

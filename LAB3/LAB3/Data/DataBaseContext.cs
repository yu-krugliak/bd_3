using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB3.Models;

namespace LAB3.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { }
        public DbSet<Rivers> Rivers { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Animals> Animals { get; set; }
        public DbSet<Waterfalls> Waterfalls { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rivers>().ToTable("Rivers");
            modelBuilder.Entity<Countries>().ToTable("Countries");
            modelBuilder.Entity<Waterfalls>().ToTable("Waterfalls");
            modelBuilder.Entity<Animals>().ToTable("Animals");
        }

        public DbSet<LAB3.Models.Visits> Visits { get; set; }
        
    }
}

       
        

      

    




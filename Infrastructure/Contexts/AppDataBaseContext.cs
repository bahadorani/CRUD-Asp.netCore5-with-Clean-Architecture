
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
  public class AppDataBaseContext : DbContext, IDataBaseContext
    {
        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options)
            : base(options)
        {
        }
        
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Check Unique in Firstname, Lastname, DateOfBirth
            //builder.Entity<Customer>().HasIndex(p => new { p.Id }).IsUnique();
            builder.Entity<Customer>().HasIndex(p => new { p.Firstname, p.Lastname, p.DateOfBirth}).IsUnique();

        }
        
    }
}

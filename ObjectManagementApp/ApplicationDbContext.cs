using Microsoft.EntityFrameworkCore;
using ObjectManagementApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ObjectManagementApp
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Use of Fluent API to define the types     
            modelBuilder.Entity<ObjectM>().Property(prop => prop.Name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<ObjectM>().Property(prop => prop.Description).HasMaxLength(50);
            modelBuilder.Entity<ObjectM>().Property(prop => prop.Type).HasMaxLength(20);
        }

        public DbSet<ObjectM> Objects { get; set; }
    }
}

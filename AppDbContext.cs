using System.Data.Entity;
using App.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = System.Data.Entity.DbContext;

namespace App
{
    public partial class AppDbContext: DbContext
    {
        public AppDbContext(string connectionString) : base(connectionString)
        {
            
        }
        public System.Data.Entity.DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

            modelBuilder.Entity<Person>().Property(e => e.DateOfBirth)
                    .IsRequired();

            modelBuilder.Entity<Person>().Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20);

            modelBuilder.Entity<Person>().Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

            modelBuilder.Entity<Person>().Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);


            modelBuilder.Entity<Person>().Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20);

            modelBuilder.Entity<Person>().HasIndex(b => b.Id)
                    .IsUnique();
        }

    }
}

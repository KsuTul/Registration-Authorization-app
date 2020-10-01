namespace WPF_APP
{
    using System.Data.Entity;
    using WPF_APP.Models;
    using DbContext = System.Data.Entity.DbContext;

    public partial class AppDbContext: DbContext
    {
        public AppDbContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<Person> People { get; set; }

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

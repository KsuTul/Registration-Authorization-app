namespace App
{
    using System.IO.Packaging;
    using WPF_APP;
    using WPF_APP.Mapping;

    public class AppDbContextFactory: IAppDbContextFactory
    {
        public AppDbContextFactory(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

        public AppDbContext Create()
        {
            return new AppDbContext(this.ConnectionString);
        }

    }
}

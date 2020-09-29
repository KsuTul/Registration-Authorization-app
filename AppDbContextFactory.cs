using System.IO.Packaging;
using App.Mapping;

namespace App
{
    public class AppDbContextFactory: IAppDbContextFactory
    {
        public AppDbContextFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

        public AppDbContext Create()
        {
            return new AppDbContext(ConnectionString);
        }

    }
}

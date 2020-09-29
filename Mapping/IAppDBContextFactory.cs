namespace App.Mapping
{
    public interface IAppDbContextFactory
    {
        public abstract AppDbContext Create();
    }
}

namespace WPF_APP.Mapping
{
    using App;

    public interface IAppDbContextFactory
    {
        public abstract AppDbContext Create();
    }
}

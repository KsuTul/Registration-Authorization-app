using App.Views;

namespace App
{
    using System.Windows;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WPF_APP.Mapping;
    using WPF_App.Services;
    using WPF_APP.Services;
    using WPF_APP.ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var service = new ServiceCollection();

            var buildProvider = RegistrationService(service, this.Configuration);

            var personViewModel = buildProvider.GetRequiredService<PersonViewModel>();
            var registrationForm = buildProvider.GetRequiredService<RegistrationForm>();
            var authorizationForm = buildProvider.GetRequiredService<Authorization>();
            var authorizationVM = buildProvider.GetRequiredService<AuthorizationViewModel>();
            registrationForm.DataContext = personViewModel;
            authorizationForm.DataContext = authorizationVM;

            var mainWindow = buildProvider.GetService<MainWindow>();

            mainWindow.Show();
        }

        public static ServiceProvider RegistrationService(IServiceCollection services, IConfiguration Configuration)
        {
            services
                .AddSingleton<IAppDbContextFactory>(new AppDbContextFactory("Default"))
                .AddSingleton<IRepository, PersonRepository>()
                .AddSingleton<PersonService>()
                .AddSingleton<PersonViewModel>()
                .AddSingleton<RegistrationForm>()
                .AddSingleton<MainWindow>()
                .AddSingleton<RegistrationForm>()
                .AddSingleton<AuthorizationViewModel>()
                .AddSingleton<Authorization>();
            return services.BuildServiceProvider();
        }
    }
}
 
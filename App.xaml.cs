using System;
using System.IO;
using System.Windows;
using App.Mapping;
using App.Services;
using App.ViewModels;
using App.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        private AppSettings _settings;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            _settings = Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

            var service = new ServiceCollection();

            var buildProvider = RegistrationService(service, Configuration);

            var personViewModel = buildProvider.GetRequiredService<PersonViewModel>();
            var registrationForm = buildProvider.GetRequiredService<RegistrationForm>();
            var authorizatonForm = buildProvider.GetRequiredService<Authorization>();
            var authorizationVM = buildProvider.GetRequiredService<AuthorizationViewModel>();
            registrationForm.DataContext = personViewModel;
            authorizatonForm.DataContext = authorizationVM;

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
 
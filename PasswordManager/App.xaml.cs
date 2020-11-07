using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services;
using PasswordManager.Domain.Services.AuthenticationServices;
using PasswordManager.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            IAuthenticationService authentication = serviceProvider.GetRequiredService<IAuthenticationService>();
            authentication.Register("test1@gmail.com", "Test1", "Test123", "Test123");

            base.OnStartup(e);
        }


        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<PasswordManagerDbContextFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            //services.AddSingleton<IDataService<User>, UserDataService>();

            return services.BuildServiceProvider();
        }

    }
}

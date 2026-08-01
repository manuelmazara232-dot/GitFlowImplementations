using Gitflow.Bussiness.Services;
using Gitflow.DataAcces.context;
using GitFlow.Entities.Interfaces.IServices;
using GitFlow.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Windows;

namespace GitFlow.UI
{
    public partial class App : Application
    {
        public static IHost? HostInstance { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            HostInstance = Host.CreateDefaultBuilder(e.Args)
                .ConfigureServices((context, services) =>
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AppConnString"]?.ConnectionString;

                    // 2. Configuramos el DbContext para que use SQL Server con esa cadena
                    services.AddDbContext<GitFlowContext>(options =>
                        options.UseSqlServer(connectionString));

                    services.AddKeyedTransient<IServices<Person>, CrudService>("CrudService");
                    services.AddTransient<MainWindow>();
                })
                .Build();

         
            HostInstance.Start();

            var mainWindow = HostInstance.Services.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (HostInstance != null)
            {
                await HostInstance.StopAsync();
                HostInstance.Dispose();
            }
            base.OnExit(e);
        }
    }
}

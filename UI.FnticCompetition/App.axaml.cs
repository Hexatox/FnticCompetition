using System.IO;
using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BL.FnticCompetition.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DL.FnticCompetition;
using DL.FnticCompetition.Repositories;
using Microsoft.EntityFrameworkCore;
using UI.FnticCompetition.ViewModel;

namespace UI.FnticCompetition
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

      public  override   void OnFrameworkInitializationCompleted()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            
            var serviceProvider = new ServiceCollection()
                .AddSingleton(configuration)
                .AddDbContext<AttendanceDbContext>(options => 
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")))
                .AddTransient<SectionRepository>()   // Register SectionRepository as Transient
                .AddTransient<SectionService>()      // Register SectionService as Transient
                .AddTransient<StudentRepository>()   // Register StudentRepository as Transient
                .AddTransient<StudentService>()      // Register StudentService as Transient
                .AddTransient<BatchRepository>()
                .AddTransient<BatchService>()
                .AddTransient<AttendanceRepository>()
                .AddTransient<AttendanceService>()
                .AddTransient<GroupRepository>()
                .AddTransient<GroupService>()
                .AddSingleton<MainViewModel>()       // Register MainViewModel as Singleton
                .BuildServiceProvider();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();

                 mainViewModel.InitializeDataAsync(); 
                desktop.MainWindow = new MainWindow(mainViewModel);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}

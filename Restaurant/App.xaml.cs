using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Restaurant.Home;
using System;
using System.Windows;
using Restaurant.Main;
using Restaurant.Restaurant1;
using Restaurant.Table;
using Restaurant.TableButton;
using Restaurant.TableHolder;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration ConfigurationProvider { get; private set; }

        public App()
        {
            ServiceProvider = createServiceProvider(ConfigurationProvider);
        }

        private IServiceProvider createServiceProvider(IConfiguration configuration)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IMainViewModel, MainViewModel>();
            serviceCollection.AddTransient<IHomeViewModel, HomeViewModel>();
            serviceCollection.AddTransient<IRestaurantViewModel, RestaurantViewModel>();
            serviceCollection.AddTransient<ITableViewModel, TableViewModel>();
            serviceCollection.AddTransient<ITableButtonViewModel, TableButtonViewModel>();
            serviceCollection.AddTransient<ITableHolderViewModel, TableHolderViewModel>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}

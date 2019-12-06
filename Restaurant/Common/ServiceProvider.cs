using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Common
{
    public static class ServiceProvider
    {
        public static IServiceProvider Instance
        {
            get
            {
                return (Application.Current as App).ServiceProvider;
            }
        }
    }
}

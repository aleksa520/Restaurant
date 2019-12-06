using Restaurant.Base.ViewModel;
using Restaurant.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Restaurant1
{
    public interface IRestaurantViewModel : IViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler<TableEventArgs> ShowTable;    

        void Start();
    }
}

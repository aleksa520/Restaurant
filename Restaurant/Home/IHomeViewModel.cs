using Restaurant.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Home
{
    public interface IHomeViewModel : IViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;
        HomeViewModelResultType? Result { get; }

        void Start();
    }
}

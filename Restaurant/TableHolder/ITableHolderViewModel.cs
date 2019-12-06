using Restaurant.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.TableHolder
{
    public interface ITableHolderViewModel : IViewModel
    {
        event EventHandler Started;
        event EventHandler Succeeded;

        void Start();

    }
}

using Restaurant.TableButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Common
{
    public class TableEventArgs : EventArgs
    {

        public TableButtonViewModel  TableButton { get; set; }

        public TableEventArgs(TableButtonViewModel tableButtonViewModel)
        {
            TableButton = tableButtonViewModel;
        }
    }
}

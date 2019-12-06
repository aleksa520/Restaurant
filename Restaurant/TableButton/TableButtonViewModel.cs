using Restaurant.Base.ViewModel;
using Restaurant.Common;
using Restaurant.Table;
using System;
using System.ComponentModel;

namespace Restaurant.TableButton
{
    public class TableButtonViewModel : ViewModelBase, ITableButtonViewModel
    {
        private int spot;
        private int tableRow;
        private int tableColumn;
       
        public event EventHandler Started;
        public event EventHandler Succeeded;

        public string BackGround { get; set; }

        public int Spot
        {
            get { return spot; }
            set
            {
                if (value != spot)
                {
                    spot = value;
                    OnPropertyChanged(nameof(Spot));
                }
            }
        }
        public int TableRow
        {
            get { return tableRow; }
            set
            {
                if (value != tableRow)
                {
                    tableRow = value;
                    OnPropertyChanged(nameof(TableRow));
                }
            }
        }
        public int TableColumn
        {
            get { return tableColumn; }
            set
            {
                if (value != tableColumn)
                {
                    tableColumn = value;
                    OnPropertyChanged(nameof(TableColumn));
                }
            }
        }

        public TableButtonViewModel()
        {
            BackGround = "green";
        }

        public void Start()
        {
            Started?.Invoke(this, new EventArgs());
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Table : INotifyPropertyChanged
    {
        private int number;
        private int tableRow;
        private int tableColumn;

        public int Number
        {
            get { return number;}
            set
            {
                if (value != number)
                {
                    number = value;
                    OnPropertyChanged(nameof(number));
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
                    OnPropertyChanged(nameof(tableRow));
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
                    OnPropertyChanged(nameof(tableColumn));
                }
            }
        }

        public Employee Employee { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

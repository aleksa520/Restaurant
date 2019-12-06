using Restaurant.Base.ViewModel;
using Restaurant.Common;
using Restaurant.Table;
using Restaurant.TableButton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Restaurant.Restaurant1
{
    public class RestaurantViewModel : ViewModelBase, IRestaurantViewModel
    {
        public static List<int> occupiedTables = new List<int>();
        private ObservableCollection<TableButtonViewModel> tableButtons;
        private RelayCommand _goBackCommand;
        private RelayCommandWithParametar<object> _tableCommand;

        public event EventHandler<TableEventArgs> ShowTable;
        public event EventHandler Started;
        public event EventHandler Succeeded;
        
        public RelayCommandWithParametar<object> TableCommand => _tableCommand;
        public RelayCommand GoBackCommand => _goBackCommand;

        public ObservableCollection<TableButtonViewModel> TableButtons
        {
            get { return tableButtons; }
            set { tableButtons = value; }
        }

        public RestaurantViewModel()
        {
            _goBackCommand = new RelayCommand(executeGoBackCommand);
            _tableCommand = new RelayCommandWithParametar<object>(parameter => executeTableCommand(parameter));
            TableButtons = new ObservableCollection<TableButtonViewModel>();
            
            TableButtons.Add(new TableButtonViewModel() { Spot = 1, TableRow = 1, TableColumn = 2 });
            TableButtons.Add(new TableButtonViewModel() { Spot = 2, TableRow = 2, TableColumn = 0 });
            TableButtons.Add(new TableButtonViewModel() { Spot = 3, TableRow = 3, TableColumn = 3 });
            TableButtons.Add(new TableButtonViewModel() { Spot = 4, TableRow = 4, TableColumn = 6 });
        }


        private void executeTableCommand(object parametar)
        {
            ShowTable?.Invoke(this, new TableEventArgs((TableButtonViewModel)parametar));
        }   

        private void executeGoBackCommand()
        {
            Succeeded?.Invoke(this, new EventArgs());
        }

        public void Start()
        {
            Started?.Invoke(this, new EventArgs());
        }
    }
}

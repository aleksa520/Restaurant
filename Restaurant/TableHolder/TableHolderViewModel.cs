using Restaurant.Base.ViewModel;
using Restaurant.Common;
using Restaurant.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.TableHolder
{
    public class TableHolderViewModel : ViewModelBase, ITableHolderViewModel
    {
        public event EventHandler Started;
        public event EventHandler Succeeded;
        private RelayCommand _goBackCommand;
        public RelayCommand GoBackCommand => _goBackCommand;
        public Domain.Table Table { get; set; }
        public ObservableCollection<Domain.Article> SelectedArticlesTableHolder { get; set; }

        public TableHolderViewModel()
        {
            _goBackCommand = new RelayCommand(executeGoBackCommand);
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

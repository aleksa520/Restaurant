using Restaurant.Base.ViewModel;
using Restaurant.Common;
using System;

namespace Restaurant.Home
{
    public enum HomeViewModelResultType
    {
        RequestRestaurant        
    }

    public class HomeViewModel : ViewModelBase, IHomeViewModel
    {
        private HomeViewModelResultType? _result;

        private RelayCommand _restaurantCommand;
        
        public event EventHandler Started;
        public event EventHandler Succeeded;
        public HomeViewModelResultType? Result => _result;

        public HomeViewModel()
        {
            _restaurantCommand = new RelayCommand(executeRestaurantCommand);
        }

        public RelayCommand RestaurantCommand => _restaurantCommand;

        private void executeRestaurantCommand()
        {
            _result = HomeViewModelResultType.RequestRestaurant;
            Succeeded?.Invoke(this, new EventArgs());
        }

        public void Start()
        {
            Started?.Invoke(this, new EventArgs());
        }
    }
}
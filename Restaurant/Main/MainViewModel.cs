using Domain;
using Restaurant.Base.ViewModel;
using Restaurant.Common;
using Restaurant.Home;
using Restaurant.Restauran.Table;
using Restaurant.Restaurant1;
using Restaurant.Table;
using Restaurant.TableButton;
using Restaurant.TableHolder;
using System;
using System.Collections.ObjectModel;

namespace Restaurant.Main
{
    public class MainViewModel : ContainerViewModelBase, IMainViewModel
    {
        private IHomeViewModel _homeViewModel;
        private IRestaurantViewModel _restaurantViewModel;
        private ITableViewModel _tableViewModel;
        private ITableButtonViewModel _tableButtonViewModel;

        public ObservableCollection<TableHolderViewModel> tables;
        public ObservableCollection<TableButtonViewModel> tableButtonViewModels;

        public MainViewModel(IHomeViewModel homeViewModel,
            IRestaurantViewModel restaurantViewModel,
            ITableButtonViewModel tableButtonViewModel,
            ITableViewModel tableViewModel)
        {
            _homeViewModel = homeViewModel;
            _homeViewModel.Started += homeViewModel_Started;
            _homeViewModel.Succeeded += homeViewModel_Succeeded;
            setHomePageCurrent();

            tables = new ObservableCollection<TableHolderViewModel>();
            tableButtonViewModels = new ObservableCollection<TableButtonViewModel>();

            _restaurantViewModel = restaurantViewModel;
            _restaurantViewModel.Started += restaurantViewModel_Started;
            _restaurantViewModel.Succeeded += restaurantViewModel_Succeeded;
            _restaurantViewModel.ShowTable += restaurantViewModel_ShowTable;

            _tableViewModel = tableViewModel;
            _tableViewModel.AddArticle += tableViewModel_AddArticle;
            _tableViewModel.Started += tableViewModel_Started;
            _tableViewModel.Succeeded += tableViewModel_Succeeded;

            _tableButtonViewModel = tableButtonViewModel;
            _tableButtonViewModel.Started += tableButtonViewModel_Started;
        }

        private void tableHolderViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = null;
            _restaurantViewModel.Start();
        }

        private void tableViewModel_AddArticle(object sender, ArticleEventArgs article)
        {
            _tableViewModel.SelectedArticles.Add(article.Article);
        }

        private void restaurantViewModel_ShowTable(object sender, TableEventArgs e)
        {
            TableButtonViewModel table = e.TableButton;

            for (int i = 0; i < tables.Count; i++)
            {
                if (table.Spot == tables[i].Table.Number)
                {
                    _tableViewModel.Table = tables[i].Table;
                    _tableViewModel.SelectedArticles = tables[i].SelectedArticlesTableHolder;
                    CurrentViewModel = _tableViewModel;
                    return;
                }
            }

            Domain.Table t = new Domain.Table
            {
                Employee = null,
                Number = table.Spot,
                TableColumn = table.TableColumn,
                TableRow = table.TableRow
            };
          

            TableHolderViewModel thvm = new TableHolderViewModel();
            thvm.Table = t;
            tables.Add(thvm);
            tableButtonViewModels.Add(table);
            _tableViewModel.Table = t;
            _tableViewModel.SelectedArticles.Clear();
            CurrentViewModel = _tableViewModel;
        }

        private void tableButtonViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _tableButtonViewModel;
        }

        private void homeViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _homeViewModel;
        }
        private void homeViewModel_Succeeded(object sender, EventArgs e)
        {
            switch (_homeViewModel.Result.Value)
            {
                case HomeViewModelResultType.RequestRestaurant:
                    CurrentViewModel = null;
                    _restaurantViewModel.Start();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private void restaurantViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _restaurantViewModel;
        }

        private void restaurantViewModel_Succeeded(object sender, EventArgs e)
        {
            CurrentViewModel = null;
            _homeViewModel.Start();
        }

        private void tableViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _tableViewModel;
        }

        private void tableViewModel_Succeeded(object sender, EventArgs e)
        {
            switch (_tableViewModel.Result.Value)
            {
                case TableViewModelResultType.RequestBack:
                    TableHolderViewModel thvm = new TableHolderViewModel();

                    int trenutniSto = _tableViewModel.Table.Number;

                    for(int i = 0; i < tables.Count; i++)
                    {
                        if(tables[i].Table.Number == trenutniSto)
                        {
                            tables[i].SelectedArticlesTableHolder = _tableViewModel.SelectedArticles;
                            break;
                        }
                    }

                    CurrentViewModel = null;
                    _restaurantViewModel.Start();
                    
                    //if(_tableViewModel.SelectedArticles.Count == 0)
                    //{
                    //    int k = _tableViewModel.Table.Number;

                    //    for(int i = 0; i < tableButtonViewModels.Count; i++)
                    //    {
                    //        if(tableButtonViewModels[i].Spot == k)
                    //        {
                    //            tableButtonViewModels[i].BackGround = "green";
                    //        }
                    //    }
                    //}
                    break;
                case TableViewModelResultType.RequestBill:
                   
                    //for (int i = 0; i < tables.Count; i++)
                    //{
                    //    if (_tableViewModel.Table.Number == tables[i].Table.Number)
                    //    {
                    //        tableButtonViewModels[i].BackGround = "green";
                    //        tables[i].SelectedArticlesTableHolder.Clear();
                    //        tables.RemoveAt(i);
                    //        tableButtonViewModels.RemoveAt(i);
                    //        break;
                    //    }
                    //}
                    CurrentViewModel = null;
                    _restaurantViewModel.Start();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void setHomePageCurrent()
        {
            CurrentViewModel = null;
            _homeViewModel.Start();
        }
    }
}
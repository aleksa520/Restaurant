using Domain;
using Restaurant.Base.ViewModel;
using Restaurant.Common;
using Restaurant.Restauran.Table;
using Restaurant.TableButton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Table
{
    public interface ITableViewModel : IViewModel
    {
        Domain.Table Table { get; set; }

        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler<ArticleEventArgs> AddArticle;
        TableViewModelResultType? Result { get; }
        ObservableCollection<Article> SelectedArticles { get; set; }

        void Start();
    }
}

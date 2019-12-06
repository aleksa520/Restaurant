using Domain;
using Restaurant.Base.ViewModel;
using Restaurant.Common;
using Restaurant.Restauran.Table;
using System;
using System.Collections.ObjectModel;

namespace Restaurant.Table
{

    public enum TableViewModelResultType
    {
        RequestArticle,
        RequestBack,
        RequestBill
    }

    public class TableViewModel : ViewModelBase, ITableViewModel
    {
        public Domain.Article Article { get; set; }
        public ObservableCollection<Domain.Article> Articles { get; set; }
        public ObservableCollection<Domain.Article> SelectedArticles { get; set; }

        public event EventHandler Started;
        public event EventHandler Succeeded;
        public event EventHandler<ArticleEventArgs> AddArticle;

        private TableViewModelResultType? _result;
        private RelayCommand _goBackCommand;
        private RelayCommand _articleCommand;
        private RelayCommand _printBill;
        private RelayCommand _addArticleCommand;

        public RelayCommand AddArticleCommand => _addArticleCommand;
        public RelayCommand GoBackCommand => _goBackCommand;
        public RelayCommand PrintBill => _printBill;
        public RelayCommand ArticleCommand => _articleCommand;
        public TableViewModelResultType? Result => _result;
        public Domain.Table Table { get; set; }

        private Article _selectedArtilce;

        public TableViewModel()
        {
            _addArticleCommand = new RelayCommand(executeAddArticleCommand);
            _goBackCommand = new RelayCommand(executeGoBackCommand);
            _articleCommand = new RelayCommand(executeArticleCommand);
            _printBill = new RelayCommand(executePrintBill);
            SelectedArticles = new ObservableCollection<Article>();
            Articles = new ObservableCollection<Domain.Article>();
            Domain.Article a = new Domain.Article
            {
                ArticleType = ArticleType.Beer,
                Description = "Pivo",
                Name = "Lasko",
                Id = Guid.NewGuid(),
                Price = 90
            };

            Domain.Article a2 = new Domain.Article
            {
                ArticleType = ArticleType.Coffee,
                Description = "Kafa",
                Name = "Domaca kafa",
                Id = Guid.NewGuid(),
                Price = 140
            };

            Domain.Article a3 = new Domain.Article
            {
                ArticleType = ArticleType.Sandwich,
                Description = "Sendvic",
                Name = "Sendvic sa sunkom",
                Id = Guid.NewGuid(),
                Price = 250
            };


            Domain.Article a4 = new Domain.Article
            {
                ArticleType = ArticleType.Tea,
                Description = "Caj",
                Name = "Caj od nane",
                Id = Guid.NewGuid(),
                Price = 110
            };

            Articles.Add(a);
            Articles.Add(a2);
            Articles.Add(a3);
            Articles.Add(a4);
        }

        public Article SelectedArticle
        {
            get { return _selectedArtilce; }
            set
            {
                if (_selectedArtilce != value)
                {
                    _selectedArtilce = value;
                    OnPropertyChanged(nameof(SelectedArticle));
                }
            }
        }

        private void executeAddArticleCommand()
        {
            Article a = SelectedArticle; 
            AddArticle?.Invoke(this, new ArticleEventArgs(a));
        }

        private void executePrintBill()
        {
            _result = TableViewModelResultType.RequestBill;
            Succeeded?.Invoke(this, new EventArgs());
        }

        private void executeArticleCommand()
        {
            _result = TableViewModelResultType.RequestArticle;
            Succeeded?.Invoke(this, new EventArgs());
        }

        public void Start()
        {
            Started?.Invoke(this, new EventArgs());
        }

        private void executeGoBackCommand()
        {
            _result = TableViewModelResultType.RequestBack;
            Succeeded?.Invoke(this, new EventArgs());
        }
    }
}

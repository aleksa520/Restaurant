using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Restauran.Table
{
    public class ArticleEventArgs : EventArgs
    {

        private readonly Article _article;

        public ArticleEventArgs(Article article)
        {
            _article = article;
        }

        public Article Article => _article;

    }
}

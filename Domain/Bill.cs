using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bill
    {
        public Guid Id { get; set; }
        public List<Article> Articles { get; set; }
        public Table Table { get; set; }
    }
}

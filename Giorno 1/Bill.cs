using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giorno_1
{
    internal class Bill
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal Amount { get; set; }
        public decimal TableService { get; set; } = 3m;
    }
}

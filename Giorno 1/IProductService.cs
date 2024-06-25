using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giorno_1
{
    internal interface IProductService
    {
        List<Product> GetProducts();
        void SelectProduct(int id);
        Bill GetBill();
        void Order();
    }
}

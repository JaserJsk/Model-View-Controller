using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Core.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(string article , string name , string description , decimal price , bool instock);

        void UpdateProduct(Guid Id , Product pr);

        Product FindById(Guid Id);

        void RemoveProduct(Guid Id);

        IEnumerable GetProducts();

    }
}

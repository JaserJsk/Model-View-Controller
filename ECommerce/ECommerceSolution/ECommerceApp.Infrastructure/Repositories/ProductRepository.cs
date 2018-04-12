using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Infrastructure.DataContext;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ECommerceContext db = new ECommerceContext();

        public void AddProduct(string article , string name , string description , decimal price , bool instock)
        {
            var addProduct = new Product();
            addProduct.Article = article;
            addProduct.ProductName = name;
            addProduct.Description = description;
            addProduct.Price = price;
            addProduct.InStock = instock;

            db.Products.Add(addProduct);
            db.SaveChanges();
        }

        public void UpdateProduct(Guid Id , Product pr)
        {
            var updateProduct = db.Products.Find(Id);
            db.Entry(updateProduct).CurrentValues.SetValues(pr);
            db.SaveChanges();
        }

        public Product FindById(Guid Id)
        {
            var findProduct = db.Products.FirstOrDefault(x => x.Id == Id);
            return findProduct;
        }

        public void RemoveProduct(Guid Id)
        {
            var removeProduct = db.Products.FirstOrDefault(x => x.Id == Id);
            db.Products.Remove(removeProduct);
        }

        public IEnumerable GetProducts()
        {
            return db.Products;
        }
    }
}

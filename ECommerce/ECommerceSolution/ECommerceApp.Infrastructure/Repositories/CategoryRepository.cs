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
    public class CategoryRepository : ICategoryRepository
    {
        private ECommerceContext db = new ECommerceContext();

        public void AddCategory(string name , string description)
        {
            var addCategory = new Category();
            addCategory.CategoryName = name;
            addCategory.Description = description;
            db.Categories.Add(addCategory);
            db.SaveChanges();
        }

        public void UpdateCategory(Guid Id, Category ca)
        {
            var updateCategory = db.Categories.Find(Id);
            db.Entry(updateCategory).CurrentValues.SetValues(ca);
            db.SaveChanges();
        }

        public Category FindById(Guid Id)
        {
            var findCategory = db.Categories.FirstOrDefault(x => x.Id == Id);
            return findCategory;
        }

        public void RemoveCategory(Guid Id)
        {
            var removeCategory = db.Categories.FirstOrDefault(x => x.Id == Id);
            db.Categories.Remove(removeCategory);
        }

        public IEnumerable GetCategories()
        {
            return db.Categories;
        }
    }
}

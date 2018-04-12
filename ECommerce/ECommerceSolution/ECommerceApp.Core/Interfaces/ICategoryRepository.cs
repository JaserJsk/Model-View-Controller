using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Core.Interfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(string name , string description);

        void UpdateCategory(Guid Id, Category ca);

        Category FindById(Guid Id);

        void RemoveCategory(Guid Id);

        IEnumerable GetCategories();
    }
}

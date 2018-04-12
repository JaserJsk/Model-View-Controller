using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Core.Interfaces
{
    public interface ICatalogRepository
    {
        void AddCatalog(string name , string description);

        void UpdateCatalog(Guid Id, Catalog ca);

        Catalog FindById(Guid Id);

        void RemoveCatalog(Guid Id);

        IEnumerable GetCatalogs();
    }
}

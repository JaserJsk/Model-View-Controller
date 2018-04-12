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
    public class CatalogRepository : ICatalogRepository
    {
        private ECommerceContext db = new ECommerceContext();

        public void AddCatalog(string name , string description)
        {
            var addCatalog = new Catalog();
            addCatalog.CatalogName = name;
            addCatalog.Description = description;
            db.Catalogs.Add(addCatalog);
            db.SaveChanges();
        }

        public void UpdateCatalog(Guid Id, Catalog ca)
        {
            var updateCatalog = db.Catalogs.Find(Id);
            db.Entry(updateCatalog).CurrentValues.SetValues(ca);
            db.SaveChanges();
        }

        public Catalog FindById(Guid Id)
        {
            var findCatalog = db.Catalogs.FirstOrDefault(x => x.Id == Id);
            return findCatalog;
        }

        public void RemoveCatalog(Guid Id)
        {
            var removeCatalog = db.Catalogs.FirstOrDefault(x => x.Id == Id);
            db.Catalogs.Remove(removeCatalog);
        }

        public IEnumerable GetCatalogs()
        {
            return db.Catalogs;
        }
    }
}

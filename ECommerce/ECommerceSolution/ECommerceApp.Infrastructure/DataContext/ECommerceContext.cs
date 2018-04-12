using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core;
using ECommerceApp.Core.Models;
using System.Web;
using ECommerceApp.Core.Inc;

namespace ECommerceApp.Infrastructure.DataContext
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext() : base("name=ECommerceAppConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Catalog> Catalogs { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<File> Files { get; set; }

    }
}

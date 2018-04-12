using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMedEntityFramework.Data
{
    public class MyDataContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
    }
}

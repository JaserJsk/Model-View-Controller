using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcMedAuth
{
    public class MyIdentityDbContext
        : IdentityDbContext<IdentityUser>
    {
        public MyIdentityDbContext()
            : base("MvcMedAuth")
        {
        }
    }
}
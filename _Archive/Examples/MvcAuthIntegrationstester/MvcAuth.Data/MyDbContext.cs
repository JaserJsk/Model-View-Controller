using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcAuth.Data.Entities;

namespace MvcAuth.Data
{
    public class MyDbContext : IdentityDbContext<User>
    {
        
    }
}

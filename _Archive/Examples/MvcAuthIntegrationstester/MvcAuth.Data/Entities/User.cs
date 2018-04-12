using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcAuth.Data.Entities
{
    public class User : IdentityUser
    {
        public bool IsAdministrator { get; set; }
    }
}

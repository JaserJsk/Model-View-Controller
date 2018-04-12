using System.Collections.Generic;

namespace MvcMedEntityFramework.Models
{
    public class AddressViewModel
    {
        public IEnumerable<string> PostalCodes { get; set; }

        public string StreetName { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMedEntityFramework.Data
{
    [Table("Address")]
    public class Address
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }

        public Address()
        {
            Id = Guid.NewGuid();
        }
    }
}

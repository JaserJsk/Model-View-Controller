using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Interfaces;

namespace ECommerceApp.Core.Models
{
    public class Category : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [ForeignKey("Catalog")]
        public Guid CatalogId { get; set; }

        public virtual Catalog Catalog { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}

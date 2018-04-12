using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Interfaces;

namespace ECommerceApp.Core.Models
{
    public class Catalog : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CatalogName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}

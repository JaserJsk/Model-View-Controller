using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Inc;
using ECommerceApp.Core.Interfaces;

namespace ECommerceApp.Core.Models
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Article { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal PriceWithTax
        {
            get
            {
                return Price * 1.125m;
            }
        }

        [Required]
        public bool InStock { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}

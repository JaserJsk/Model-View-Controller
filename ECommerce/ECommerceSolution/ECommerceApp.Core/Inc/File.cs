using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Core.Inc
{
    public enum FileType
    {
        Avatar = 1, Photo
    }

    public class File : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public FileType FileType { get; set; }

        public virtual Product Product { get; set; }

    }
}

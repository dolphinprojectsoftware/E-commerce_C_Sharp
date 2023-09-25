using Ecommerce.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Product :  BaseEntity
    {
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public decimal? UnitPrice { get; set; }
        public short? UnitInStock { get; set; }
        public short? UnitOnOrder { get; set; }
    }
}

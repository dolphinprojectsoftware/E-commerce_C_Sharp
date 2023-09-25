using Ecommerce.Api.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.DTOs
{
    public class ProductDTO : BaseDTO
    {
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public decimal? UnitPrice { get; set; }
        public short? UnitInStock { get; set; }
        public short? UnitOnOrder { get; set; }
    }
}

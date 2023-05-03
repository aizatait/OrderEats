using OrderEats.Core.DTO.Product;
using OrderEats.Core.DTOs;
using System.ComponentModel.DataAnnotations;

namespace OrderEats.Core.DTO.Cart
{
    public class CartItemDto : TrackingEntityDto
    {
        [Required]
        public int CartId { get; set; }

        public CartDto? Cart { get; set; }

        public int ProductId { get; set; }

        public ProductInfoDto? Product { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Quantity { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}

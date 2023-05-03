using OrderEats.Core.DTOs;
using System.ComponentModel.DataAnnotations;

namespace OrderEats.Core.DTO.Cart
{
    public class CartDto : TrackingEntityDto
    {
        public CartDto()
        {
            CartItems = new List<CartItemDto>();
        }

        [Required]
        public int UserId { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

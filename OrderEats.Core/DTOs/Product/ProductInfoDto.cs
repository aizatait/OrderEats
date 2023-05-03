using OrderEats.Core.DTOs;

namespace OrderEats.Core.DTO.Product
{
    public class ProductInfoDto : TrackingEntityDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string? Picture { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public ICollection<ProductPropertyDto> ProductProperties { get; set; }
    }
}

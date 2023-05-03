using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderEats.Core.Models
{
    public class Product : TrackingEntity
    {
        public Product()
        {
            ProductProperties = new List<ProductProperty>();
        }

        [Required]
        public long CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [MaxLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string? Picture { get; set; }

        public decimal? Price { get; set; }


        [MaxLength(256)]
        public string? Description { get; set; }

        public ICollection<ProductProperty> ProductProperties { get; set; }
    }
}

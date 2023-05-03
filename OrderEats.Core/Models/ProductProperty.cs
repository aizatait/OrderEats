using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderEats.Core.Models
{
    public class ProductProperty : TrackingEntity
    {
        [Required]
        public long ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [MaxLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [MaxLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string ValueType { get; set; }

        public int? IntValue { get; set; }

        [MaxLength(256)]
        public string? StringValue { get; set; }

        public bool? BooleanValue { get; set; }

        public decimal? DecimalValue { get; set; }
    }
}

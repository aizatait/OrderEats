using System.ComponentModel.DataAnnotations;

namespace OrderEats.Core.Models
{
    public class Category : TrackingEntity
    {
        [MaxLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}

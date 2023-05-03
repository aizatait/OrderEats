using System.ComponentModel.DataAnnotations;

namespace OrderEats.Core.DTOs
{
    /// <summary>
    /// Base tracking entity DTO.
    /// </summary>
    public abstract class TrackingEntityDto : BaseEntityDto
    {
        /// <summary>
        /// Creation date.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Update date.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// User ID who created entity.
        /// </summary>
        [Required]
        public long CreatedById { get; set; }

        /// <summary>
        /// User ID who updated entity.
        /// </summary>
        public long UpdatedById { get; set; }
    }
}

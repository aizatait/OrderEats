using OrderEats.Core.Abstractions.Data;

namespace OrderEats.Core.Models
{
    /// <summary>
    /// Base tracking entity.
    /// </summary>
    public abstract class TrackingEntity : BaseEntity, ITrackingEntity
    {
        /// <inheritdoc />
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc />
        public DateTime UpdatedAt { get; set; }

        /// <inheritdoc />
        public long CreatedById { get; set; }

        /// <inheritdoc />
        public long UpdatedById { get; set; }
    }
}

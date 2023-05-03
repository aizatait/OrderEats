namespace OrderEats.Core.Abstractions.Data
{
    /// <summary>
    /// Common tracking entity interface.
    /// </summary>
    public interface ITrackingEntity : IEntity
    {
        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Update date.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// User ID who created entity.
        /// </summary>
        public long CreatedById { get; set; }

        /// <summary>
        /// User ID who updated entity.
        /// </summary>
        public long UpdatedById { get; set; }
    }
}

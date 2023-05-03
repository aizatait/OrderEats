namespace OrderEats.Core.Abstractions.DTO
{
    /// <summary>
    /// A base entity common interface.
    /// </summary>
    public interface IBaseEntityDto<TKey> : IDto
    {
        /// <summary>
        /// Entity ID.
        /// </summary>
        public TKey Id { get; }
    }
}

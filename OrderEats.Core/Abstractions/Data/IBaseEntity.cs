namespace OrderEats.Core.Abstractions.Data
{
    /// <summary>
    /// Common base entity interface.
    /// </summary>
    public interface IBaseEntity<TKey> : IEntity
    {
        /// <summary>
        /// Entity unique identifier.
        /// </summary>
        TKey Id { get; }
    }
}

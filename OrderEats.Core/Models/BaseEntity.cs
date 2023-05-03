using OrderEats.Core.Abstractions.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderEats.Core.Models
{
    /// <summary>
    /// Base entity.
    /// </summary>
    public abstract class BaseEntity : IBaseEntity<long>
    {
        /// <inheritdoc />
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}

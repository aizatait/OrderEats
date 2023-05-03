using OrderEats.Core.Abstractions.DTO;
using System.ComponentModel.DataAnnotations;

namespace OrderEats.Core.DTOs
{
    /// <summary>
    /// Base entity DTO.
    /// </summary>
    public abstract class BaseEntityDto : IBaseEntityDto<long>
    {
        /// <inheritdoc />
        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Id must be positive number.")]
        public long Id { get; set; }
    }
}

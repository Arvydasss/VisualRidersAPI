using apiForVisualRiders.Models;
using Microsoft.Build.Framework;

namespace APIforVisualRiders.Models.Dtos
{
    public class UpdateEmployeeRoleDto
    {
        [Required]
        public Guid roleId { get; set; }
    }
}
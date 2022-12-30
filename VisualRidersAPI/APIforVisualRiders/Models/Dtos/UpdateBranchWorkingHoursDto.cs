using apiForVisualRiders.Models;
using Microsoft.Build.Framework;

namespace APIforVisualRiders.Models.Dtos
{
    public class UpdateBranchWorkingHoursDto
    {
        [Required]
        public Time WorkingHourStart { get; set; }

        [Required]
        public Time WorkingHourEnd { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Security
{
    public class ChangePassword
    {
        [Required, DataType(DataType.Password)]
        public string OldPassword { get; set; } = default!;

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; } = default!;
    }
}

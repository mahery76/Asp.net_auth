using System.ComponentModel.DataAnnotations;

namespace RestoMvc.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string UserName { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [StringLength(
            100,
            MinimumLength = 6,
            ErrorMessage = "Password must be between 6 and 100 characters."
        )]
        public string Password { get; set; } = "";

        public string Role { get; set; } = "Everyone";
    }
}

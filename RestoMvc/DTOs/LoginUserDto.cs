using System.ComponentModel.DataAnnotations;
namespace RestoMvc.DTOs
{
    public class LoginUserDto
    {
        [Required]
        public string UserName { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }
}

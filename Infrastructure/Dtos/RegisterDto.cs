using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        
        // [Required]
        // [Compare(nameof(Password), ErrorMessage = "密碼輸入不一致")]
        // public string ConfirmPassword { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
namespace BookApp.Models
{
    public class Register
    {
        [Required]
        public string? UserName { get; set; }
        
        [Required]
        public string? Email { get; set; } 

        [Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }  

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string? ComfirmPassword { get; set; } 
    }
}
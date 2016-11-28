using System.ComponentModel.DataAnnotations;

namespace WasteAway.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
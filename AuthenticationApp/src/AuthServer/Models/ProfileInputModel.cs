using System.ComponentModel.DataAnnotations;

namespace AuthServer.Models
{
    public class ProfileInputModel
    {
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Bio")]
        [DataType(DataType.Text)]
        public string Bio { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

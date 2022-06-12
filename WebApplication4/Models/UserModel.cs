using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string FullName { get; set; }


        [Required]
        [Range(1, 3, ErrorMessage = "Please enter the correct value")]
        public int UserType { get; set; }

       
        public int company_id { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email  { get; set; }

        

    }
}

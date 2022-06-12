using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class CompanyModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public  UserModel LoggedUser { get; set; }



    }
}

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Disaster_Alleviation_Foundation.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "username")]
        [Required(ErrorMessage = "You need to enter your Username")]
        public string name { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You need to enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "You need to enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

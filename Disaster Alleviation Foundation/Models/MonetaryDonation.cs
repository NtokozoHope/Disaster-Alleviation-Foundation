using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Disaster_Alleviation_Foundation.Models
{
    public class MonetaryDonation
    {
        [Key]
        public int MonetaryDonationID { get; set; }

        [Display(Name = "Name")]
        [StringLength(100)]
        public string Donor { get; set; }

        [Required(ErrorMessage = "You need to enter the Date")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You need to enter the Amount")]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
    }
}


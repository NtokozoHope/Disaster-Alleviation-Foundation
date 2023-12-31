﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Disaster_Alleviation_Foundation.Models
{
    public class GoodsDonation
    {
        [Key]
        public int GoodsDonationID { get; set; }

        public string Donor { get; set; }

        [Required(ErrorMessage = "You need to enter the Date")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You need to enter the Number of Items")]
        [Display(Name = "Number of Items")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of Items must be greater than 0")]
        public int Number_Of_Items { get; set; }

        [Required(ErrorMessage = "You need to enter the Category")]
        [Display(Name = "Category")]
        [StringLength(100)]
        public string Category { get; set; }

        [Required(ErrorMessage = "You need to enter the Description")]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }

        
    }
}

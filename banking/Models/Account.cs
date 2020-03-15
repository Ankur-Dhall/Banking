using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace banking.Models
{
    public class Account
    {
        [Key]
        [Range(1000000000,2000000000)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Account Number")]
        public int AccountNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression("[0-9][0-9][0-9][0-9]")]
        public string Pin { get; set; }

        public int Balance { get; set; }


        [Display(Name = "Phone Number")]
        [RegularExpression("[7-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]")]
        [Required]
        public string PhoneNumber { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace banking.Models
{
    public class Payee
    {
        public int Id { get; set; }
        [Range(1000000000, 2000000000)]
        public int SenderAccountNumber { get; set; }


        [Range(1000000000, 2000000000)]
        public int PayeeAccountNumber { get; set; }


        [Required]
        public string PayeeName { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression("[7-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]")]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
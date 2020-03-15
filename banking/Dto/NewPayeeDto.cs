using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banking.Dto
{
    public class NewPayeeDto
    {
        public int SenderAccountNumber { get; set; }
        public int PayeeAccountNumber { get; set; }
        public string PayeeName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
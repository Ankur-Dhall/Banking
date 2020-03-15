using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banking.Dto
{
    public class AccountDto
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string PhoneNumber { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banking.Dto
{
    public class WithdrawAndDepositDto
    {
        public int AccountNumber { get; set; }
        public string pin { get; set; }
        public int Amount { get; set; }
    }
}
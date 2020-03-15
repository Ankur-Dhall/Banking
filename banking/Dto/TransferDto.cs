using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banking.Dto
{
    public class TransferDto
    {
        public int AccountNumber { get; set; }
        public string pin { get; set; }
        public int Amount { get; set; }
        public int receiver { get; set; }
    }
}
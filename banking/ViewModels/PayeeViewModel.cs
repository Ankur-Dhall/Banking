using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banking.ViewModels
{
    public class PayeeViewModel
    {
        public int? SenderAccountNumber { get; set; }
        public int PayeeAccountNumber { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace banking.Dto
{
    public class ChangeDto
    {
        public int AccountNumber { get; set; }
        public string OldPin { get; set; }
        public string NewPin { get; set; }
    }
}
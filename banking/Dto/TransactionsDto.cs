using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using banking.Models;

namespace banking.Dto
{
    public class TransactionsDto
    {
        public int Amount { get; set; }
        public string Receiver { get; set; }
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }

    }
}
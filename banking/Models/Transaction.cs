using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace banking.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }

        [Range(1,50000)]
        public int Amount { get; set; }
        public string Receiver { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public TransactionType TransactionType { get; set; }
        public byte TransactionTypeId { get; set; }

        public static readonly byte Withdraw = 1;
        public static readonly byte Deposit = 2;
        public static readonly byte ThirdPartyTransfer = 3;



    }
}
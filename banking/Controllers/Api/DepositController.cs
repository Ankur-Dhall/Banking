using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using banking.Models;
using banking.Dto;

namespace banking.Controllers.Api
{
    public class DepositController : ApiController
    {
        ApplicationDbContext _context;
        public DepositController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPut]
        public IHttpActionResult Deposit(WithdrawAndDepositDto depositDto)
        {
            var customer = _context.Accounts.Single(x => x.AccountNumber == depositDto.AccountNumber);
            if (customer.Pin != depositDto.pin)
            {
                return Ok("Incorrect Pin");
            }
            if (depositDto.Amount>5000)
            {
                return Ok("Cannot deposit more than $5000 at a time.");
            }
            else
            {
                customer.Balance = customer.Balance + depositDto.Amount;

                Transaction current = new Transaction();
                current.AccountNumber = depositDto.AccountNumber;
                current.Amount = depositDto.Amount;
                current.Date = DateTime.Now;
                current.TransactionTypeId = Transaction.Deposit;
                _context.Transactions.Add(current);

                _context.SaveChanges();
                return Ok(customer.Balance);
            }

        }
    }
}

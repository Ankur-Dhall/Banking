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
    public class WithdrawController : ApiController
    {
        ApplicationDbContext _context;
        public WithdrawController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPut]
        public IHttpActionResult Withdraw(WithdrawAndDepositDto withdrawDto)
        {
            var customer = _context.Accounts.Single(x => x.AccountNumber == withdrawDto.AccountNumber);
            if(customer.Pin != withdrawDto.pin)
            {
                return Ok("Incorrect Pin");
            }
            else if(customer.Balance<withdrawDto.Amount)
            {
                return Ok("Insufficient Balance");;
            }
            else
            {
                customer.Balance = customer.Balance - withdrawDto.Amount;

                Transaction current = new Transaction();
                current.AccountNumber = withdrawDto.AccountNumber;
                current.Amount = withdrawDto.Amount;
                current.Date = DateTime.Now;
                current.TransactionTypeId = Transaction.Withdraw;
                _context.Transactions.Add(current);

                _context.SaveChanges();
                return Ok(customer.Balance);
            }

        }
    }
}

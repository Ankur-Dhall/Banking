using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using banking.Models;
using banking.Dto;
using AutoMapper;

namespace banking.Controllers.Api
{
    public class TransferController : ApiController
    {
        ApplicationDbContext _context;
        public TransferController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetPayees(int Id)
        {
            var payeesDto = _context.Payees
                .Where(x => x.SenderAccountNumber == Id)
                .ToList()
                .OrderBy(y=>y.PayeeName)
                .Select(Mapper.Map<Payee,PayeeDto>);
            return Ok(payeesDto);
        }

        [HttpPost]
        public IHttpActionResult AddNewPayee(NewPayeeDto newPayeeDto)
        {
            if(_context.Payees
                .Where(y=>y.SenderAccountNumber == newPayeeDto.SenderAccountNumber)
                .SingleOrDefault(x => x.PayeeAccountNumber == newPayeeDto.PayeeAccountNumber)
                != null)
            {
                return Ok("You already have that payee.");
            }

            if(newPayeeDto.PayeeAccountNumber == newPayeeDto.SenderAccountNumber)
            {
                return Ok("You cannot add yourself as Payee");
            }

            var payee = _context.Accounts.SingleOrDefault(x => x.AccountNumber == newPayeeDto.PayeeAccountNumber);
            if(payee == null)
            {
                return Ok("Payee Account Number does not exist.");
            }

            else if(payee.PhoneNumber != newPayeeDto.PhoneNumber)
            {
                return Ok("Account Number and Phone Number does not match.");
            }

            Payee newPayee = new Payee();
            newPayee = Mapper.Map<NewPayeeDto, Payee>(newPayeeDto);
            _context.Payees.Add(newPayee);
            _context.SaveChanges();

            return Ok(newPayee.PayeeAccountNumber);
        }

        [HttpPut]
        public IHttpActionResult ThirdPartyTransfer(TransferDto TransferDto)
        {
            var sender = _context.Accounts.Single(x => x.AccountNumber == TransferDto.AccountNumber);
            var receiver = _context.Accounts.SingleOrDefault(x => x.AccountNumber == TransferDto.receiver);
            if (sender.Pin != TransferDto.pin)
            {
                return Ok("Incorrect Pin");
            }
            else if (sender.Balance < TransferDto.Amount)
            {
                return Ok("Insufficient Balance");
            }
            else if(receiver == null)
            {
                return Ok("Incorrect Receiver Account Number");
            }
            receiver.Balance = receiver.Balance + TransferDto.Amount;
            sender.Balance = sender.Balance - TransferDto.Amount;

            Transaction current = new Transaction();
            current.AccountNumber = TransferDto.AccountNumber;
            current.Amount = TransferDto.Amount;
            current.Date = DateTime.Now;
            current.TransactionTypeId = Transaction.ThirdPartyTransfer;
            current.Receiver = receiver.Name;
            _context.Transactions.Add(current);

            _context.SaveChanges();
            return Ok(sender.Balance);
        }
    }
}

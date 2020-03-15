using AutoMapper;
using banking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using banking.Dto;

namespace banking.Controllers.Api
{
    public class TransactionsController : ApiController
    {
        ApplicationDbContext _context;
        public TransactionsController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetTransactions(int id)
        {
            var TransactionsDto = _context.Transactions
                .Where(m => m.AccountNumber == id)
                .Include(x => x.TransactionType)
                .OrderByDescending(m => m.Date)
                .Select(Mapper.Map<Transaction, TransactionsDto>);
            return Ok(TransactionsDto);
        }
    }
}

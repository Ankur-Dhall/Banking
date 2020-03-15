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
    public class ChangeController : ApiController
    {
        ApplicationDbContext _context;
        public ChangeController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPut]
        public IHttpActionResult Change(ChangeDto changeDto)
        {
            var customer = _context.Accounts.Single(x => x.AccountNumber == changeDto.AccountNumber);
            if(changeDto.OldPin != customer.Pin)
            {
                return Ok("Pin that you have entered is incorrect.");
            }
            if (changeDto.OldPin == changeDto.NewPin)
            {
                return Ok("New pin cannot be same as old pin.");
            }
            customer.Pin = changeDto.NewPin;
            _context.SaveChanges();
            return Ok(int.Parse(customer.Pin));
        }
    }
}

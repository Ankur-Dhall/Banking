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
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize(Roles = Roles.CustomerManager)]
        public IHttpActionResult GetCustomers()
        {
            var customersDto = _context.Accounts.Select(Mapper.Map<Account, CustomersDto>);
            return Ok(customersDto);
        }
        [HttpPost]
        public IHttpActionResult NewCustomer(NewCustomerDto newCustomerDto)
        {
            Account newCustomer = new Account()
            {
                Name = newCustomerDto.Name,
                PhoneNumber = newCustomerDto.PhoneNumber,
                Balance = newCustomerDto.Balance,
                Pin = "0000"
            };
            newCustomer.AccountNumber = 1000000000;
            _context.Accounts.Add(newCustomer);
            _context.SaveChanges();
            return Ok();
        }
    }
}

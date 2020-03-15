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
    public class DetailsController : ApiController
    {
        ApplicationDbContext _context;
        public DetailsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetDetails(int id)
        {
            var details = _context.Accounts.SingleOrDefault(x => x.AccountNumber == id);
            if(details == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Account, AccountDto>(details));
        }
    }
}

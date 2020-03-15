using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using banking.Models;
using banking.Dto;
using AutoMapper.Configuration;

namespace banking.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Account, AccountDto>();
            Mapper.CreateMap<Account, AccountDto>();
            Mapper.CreateMap<Transaction, TransactionsDto>();
            Mapper.CreateMap<Account, CustomersDto>();
            Mapper.CreateMap<Payee, PayeeDto>();
            Mapper.CreateMap<NewPayeeDto, Payee>();
        }
    }
}
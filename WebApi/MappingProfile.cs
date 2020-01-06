using System;
using AutoMapper;
using Transactions.Common.Models;
using WebApi.Controllers.Transactions;

namespace WebApi
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExpenseSaveRequest, Expense>()
            .ForMember(d => d.LastChangedBy, o => o.Ignore())
            .ForMember(d => d.LastModifiedUTC, o => o.Ignore())
            .ForMember(d => d.CreatedUTC, o => o.Ignore());
            CreateMap<IncomeSaveRequest, Income>()
             .ForMember(d => d.LastChangedBy, o => o.Ignore())
             .ForMember(d => d.LastModifiedUTC, o => o.Ignore())
             .ForMember(d => d.CreatedUTC, o => o.Ignore());
        }
    }
}
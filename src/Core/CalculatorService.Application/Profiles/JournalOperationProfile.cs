using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CalculatorService.Api.Contracts.DTOs;
using CalculatorService.Domain.Entities;

namespace CalculatorService.Application.Profiles
{
    public class JournalOperationProfile : Profile
    {
        public JournalOperationProfile()
        {
            CreateMap<JournalOperation, OperationDto>();
        }
    }
}

using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Dto.Converter.Function;
using AorangiPeak.Dto.FunctionDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Dto.MappingProfile
{
    public class FunctionMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Function, FunctionBriefDto>();
            CreateMap<Function, FunctionDetailDto>();

            CreateMap<NewFunctionDto, Function>().ConvertUsing<NewFunctionDtoToMenuEntity>();
            CreateMap<FunctionDetailDto, Function>().ConvertUsing<FunctionDetailDtoToMenuEntity>();
            CreateMap<FunctionDeleteDto, Function>().ConvertUsing<FunctionDeleteDtoToMenuEntity>();
        }
    }
}

using AorangiPeak.Dto.FunctionDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AorangiPeak.Domain.Core.Model;

namespace AorangiPeak.Dto.Converter.Function
{
    public class FunctionBriefDtoToMenuEntity : ITypeConverter<FunctionBriefDto, Domain.Core.Model.Function>
    {
        public Domain.Core.Model.Function Convert(FunctionBriefDto source, Domain.Core.Model.Function destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}

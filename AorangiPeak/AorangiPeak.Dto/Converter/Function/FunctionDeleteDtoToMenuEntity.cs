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
    public class FunctionDeleteDtoToMenuEntity : ITypeConverter<FunctionDeleteDto, Domain.Core.Model.Function>
    {
        public Domain.Core.Model.Function Convert(FunctionDeleteDto source, Domain.Core.Model.Function destination, ResolutionContext context)
        {
            return new Domain.Core.Model.Function(source.Id);
        }
    }
}

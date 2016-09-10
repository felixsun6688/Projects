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
    public class NewFunctionDtoToMenuEntity : ITypeConverter<NewFunctionDto, Domain.Core.Model.Function>
    {
        public Domain.Core.Model.Function Convert(NewFunctionDto source, Domain.Core.Model.Function destination, ResolutionContext context)
        {
            return new Domain.Core.Model.Function(System.Guid.NewGuid(),
                                                                            source.Functionname,
                                                                            source.Firstimg,
                                                                            source.Introduction,
                                                                            source.Content,
                                                                            source.Status);
        }
    }
}

using AorangiPeak.Dto.FunctionDto;
using AutoMapper;

namespace AorangiPeak.Dto.Converter.Function
{
    public class FunctionDetailDtoToMenuEntity : ITypeConverter<FunctionDetailDto, Domain.Core.Model.Function>
    {
        public Domain.Core.Model.Function Convert(FunctionDetailDto source, Domain.Core.Model.Function destination, ResolutionContext context)
        {
            return new Domain.Core.Model.Function(source.Id,
                                                                            source.Functionname,
                                                                            source.Firstimg,
                                                                            source.Introduction,
                                                                            source.Content,
                                                                            source.Status);
        }
    }
}

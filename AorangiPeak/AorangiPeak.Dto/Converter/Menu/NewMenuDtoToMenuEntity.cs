using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Dto.MenuDto;
using AutoMapper;
using System;

namespace AorangiPeak.Dto.Converter.Menu
{
    public class NewMenuDtoToMenuEntity : ITypeConverter<NewMenuDto, Domain.Core.Model.Menu>
    {
        public Domain.Core.Model.Menu Convert(NewMenuDto source, Domain.Core.Model.Menu destination, ResolutionContext context)
        {
            return new Domain.Core.Model.Menu(Guid.NewGuid(),
                                                                       source.Menuname,
                                                                       source.Firstimg,
                                                                       source.Secondimg,
                                                                       source.Introduction,
                                                                       source.Content,
                                                                       MenuStatus.Active);
        }
    }
}

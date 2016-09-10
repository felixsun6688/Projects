using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Dto.MenuDto;
using AutoMapper;

namespace AorangiPeak.Dto.Converter.Menu
{
    public class MenuDetailDtoToMenuEntity : ITypeConverter<MenuDetailDto, Domain.Core.Model.Menu>
    {
        public Domain.Core.Model.Menu Convert(MenuDetailDto source, Domain.Core.Model.Menu destination, ResolutionContext context)
        {
            return new Domain.Core.Model.Menu(source.Id,
                                                                       source.Menuname,
                                                                       source.Firstimg,
                                                                       source.Secondimg,
                                                                       source.Introduction,
                                                                       source.Content,
                                                                       MenuStatus.Active);
        }
    }
}

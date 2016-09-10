using AorangiPeak.Dto.MenuDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AorangiPeak.Domain.Core.Model;

namespace AorangiPeak.Dto.Converter.Menu
{
    public class MenuDeleteDtoToMenuEntity : ITypeConverter<MenuDeleteDto, Domain.Core.Model.Menu>
    {
        public Domain.Core.Model.Menu Convert(MenuDeleteDto source, Domain.Core.Model.Menu destination, ResolutionContext context)
        {
            return new Domain.Core.Model.Menu(source.Id);
        }
    }
}

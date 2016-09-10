using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Dto.MenuDto;

namespace AorangiPeak.Dto.Converter.Menu
{
    public class MenuBriefDtoToMenuEntity : ITypeConverter<MenuBriefDto, Domain.Core.Model.Menu>
    {
        public Domain.Core.Model.Menu Convert(MenuBriefDto source, Domain.Core.Model.Menu destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}

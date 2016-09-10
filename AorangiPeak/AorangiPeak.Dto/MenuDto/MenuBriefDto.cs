using AorangiPeak.Domain.Core.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Dto.MenuDto
{
    public class MenuBriefDto : IOutputDto
    {
        public string Menuname { get;  set; }
        public string Firstimg { get;  set; }
        public string Introduction { get;  set; }
        public MenuStatus Status { get; set; }

        public Guid Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Dto.MenuDto
{
    public class MenuDetailDto :IDto
    {
        public string Menuname { get; set; }
        public string Firstimg { get; set; }
        public string Secondimg { get; set; }
        public string Introduction { get; set; }
        public string Content { get; set; }

        public Guid Id { get; set; }
    }
}

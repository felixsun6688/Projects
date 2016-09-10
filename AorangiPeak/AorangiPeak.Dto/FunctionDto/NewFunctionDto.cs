using AorangiPeak.Domain.Core.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Dto.FunctionDto
{
    public class NewFunctionDto : IInputDto
    {
        public string Functionname { get; set; }
        public string Firstimg { get; set; }
        public string Introduction { get; set; }
        public string Content { get; set; }
        public FunctionStatus Status { get; set; }
    }
}

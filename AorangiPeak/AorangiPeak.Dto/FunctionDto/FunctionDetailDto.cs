using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Dto.FunctionDto
{
    public class FunctionDetailDto : IDto
    {
        public string Functionname { get;  set; }
        public string Firstimg { get;  set; }
        public string Introduction { get;  set; }
        public string Content { get;  set; }
        public FunctionStatus Status { get;  set; }

        public Guid Id { get; set; }
    }
}

using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Dto.RoleDto
{
    /// <summary>
    /// RoleDetailDto for displaying and editing role
    /// </summary>
    public class RoleDetailDto : IDto
    {
        public string Rolename { get; set; }
        public DateTime Createtime { get; set; }
        public RoleStatus Status { get; set; }
    }
}

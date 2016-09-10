using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Dto.RoleDto
{
    /// <summary>
    /// RoleBriefDto for listing roles
    /// </summary>
    public class RoleBriefDto : IOutputDto
    {
        public string Rolename { get; set; }
        public int Useramount { get; set; }
        public DateTime Createtime { get; set; }
        public RoleStatus Status { get; set; }

        public Guid Id { get; set; }
    }
}

using AorangiPeak.Dto.MappingProfile;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Dto
{
    public class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserMappingProfile>();
                cfg.AddProfile<RoleMappingProfile>();
                cfg.AddProfile<MenuMappingProfile>();
                cfg.AddProfile<TableBookingMappingProfile>();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shopping.Models.DTO;

namespace Shopping.Models.AutoMapping
{
    public class AutoMappingProfiles:Profile
    {
        public AutoMappingProfiles()
        {
            //CreateMap<UserDetails, UserLoginDetails>().ForMember().ReverseMap();
        }
    }
}

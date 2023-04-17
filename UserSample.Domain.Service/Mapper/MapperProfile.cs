using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSample.Data.Service.Entities;
using UserSample.Domain.Service.Models.User;

namespace UserSample.Domain.Service.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserRequestDto, User>();
            CreateMap<UserResponseDto, User>().ReverseMap();
        }
    }
}

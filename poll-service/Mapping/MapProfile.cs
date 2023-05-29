using AutoMapper;
using poll_core.DTOs;
using poll_core.DTOs.Poll;
using poll_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poll_service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, AdminUserDto>().ReverseMap();
            CreateMap<UserDto, AdminUserDto>().ReverseMap();
            CreateMap<Poll, PollDto>().ReverseMap();
            CreateMap<PollOption, PollOptionDto>().ReverseMap();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserWithRoleDto>();
            CreateMap<Role, RoleWithUsersDto>();
        }
    }
}

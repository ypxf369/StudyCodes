using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TPSite.Domain.Entities;
using TPSite.Dto;

namespace TPSite.Extras.AutoMapper.MapProfile
{
    public class UserProfile : Profile, IProfile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>()
                .ForMember(i => i.IsEmailConfirmed, i => i.Ignore())
                .ForMember(i => i.IsPhoneNumConfirmed, i => i.Ignore())
                .ForMember(i => i.IsDeleted, i => i.Ignore())
                .ForMember(i => i.CreationTime, i => i.Ignore());
        }
    }
}

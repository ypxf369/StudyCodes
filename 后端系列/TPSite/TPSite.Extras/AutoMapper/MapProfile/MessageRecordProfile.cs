using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TPSite.Domain.Entities;
using TPSite.Dto;

namespace TPSite.Extras.AutoMapper.MapProfile
{
    public class MessageRecordProfile : Profile, IProfile
    {
        public MessageRecordProfile()
        {
            CreateMap<MessageRecord, MessageRecordDto>();

            CreateMap<MessageRecordDto, MessageRecord>()
                .ForMember(i => i.IsDeleted, i => i.Ignore())
                .ForMember(i => i.CreationTime, i => i.Ignore());
        }
    }
}

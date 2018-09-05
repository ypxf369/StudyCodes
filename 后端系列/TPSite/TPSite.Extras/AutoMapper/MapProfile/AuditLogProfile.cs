using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TPSite.Domain.Entities;
using TPSite.Dto;

namespace TPSite.Extras.AutoMapper.MapProfile
{
    public class AuditLogProfile : Profile, IProfile
    {
        public AuditLogProfile()
        {
            CreateMap<AuditLog, AuditLogDto>();

            CreateMap<AuditLogDto, AuditLog>()
                .ForMember(i => i.IsDeleted, i => i.Ignore());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TPSite.Domain.Entities;
using TPSite.Dto;
using TPSite.EntityFrameworkCore;
using TPSite.IService.Convention;

namespace TPSite.IService
{
    public interface IAuditLogService : IEfCoreRepository<AuditLog, AuditLogDto, Guid>, IServiceSupport
    {
    }
}

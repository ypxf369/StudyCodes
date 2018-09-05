using System;
using System.Collections.Generic;
using System.Text;
using TPSite.Domain.Entities;
using TPSite.Dto;
using TPSite.EntityFrameworkCore;
using TPSite.IService;

namespace TPSite.Service
{
    public sealed class AuditLogService : EfCoreRepositoryBase<AuditLog, AuditLogDto, Guid>, IAuditLogService
    {

    }
}

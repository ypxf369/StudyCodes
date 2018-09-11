using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPSite.Domain.Entities;
using TPSite.Dto;
using TPSite.EntityFrameworkCore;
using TPSite.IService.Convention;

namespace TPSite.IService
{
    public interface IMessageRecordService : IEfCoreRepository<MessageRecord, MessageRecordDto, Guid>, IServiceSupport
    {
        Task<IList<MessageRecordDto>> GetHistoryMessagePagedAsync(Guid fromUserId, Guid toUserId, int pageSize, int pageIndex);
    }
}

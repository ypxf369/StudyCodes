using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using TPSite.Domain.Entities;
using TPSite.Dto;
using TPSite.EntityFrameworkCore;
using TPSite.IService;

namespace TPSite.Service
{
    public sealed class MessageRecordService : EfCoreRepositoryBase<MessageRecord, MessageRecordDto, Guid>, IMessageRecordService
    {
        public override IQueryable<MessageRecord> GetAllIncluding()
        {
            return GetAll()
                .Include(i => i.FromUser)
                .Include(i => i.ToUser);
        }

        public async Task<IList<MessageRecordDto>> GetHistoryMessagePagedAsync(Guid userId, int pageSize, int pageIndex)
        {
            var messages = await GetAll()
                .Where(i => i.FromUserId == userId || i.ToUserId == userId)
                .OrderBy(i => i.CreationTime)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<MessageRecordDto>()
                .ToListAsync();
            return messages;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPSite.Domain.Entities;
using TPSite.Domain.Enum;
using TPSite.Dto;
using TPSite.EntityFrameworkCore;
using TPSite.IService.Convention;

namespace TPSite.IService
{
    public interface IUserService : IEfCoreRepository<User, UserDto, Guid>, IServiceSupport
    {
        /// <summary>
        /// 检查用户名是否存在，true存在，false不存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        Task<bool> CheckUserNameDupAsync(string userName);
        Task<bool> CheckPhoneDupAsync(string mobile);
        Task<bool> CheckEmailDupAsync(string email);
        Task<(LoginResults, UserDto)> CheckUserPasswordAsync(string userNameOrEmailOrMobile, string password);
        Task<UserDto> GetUserByUserNameOrEmailOrMobileAsync(string userNameOrEmailOrPhone);
    }
}

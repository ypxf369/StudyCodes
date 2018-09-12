using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TPSite.Domain.Entities;
using TPSite.Domain.Enum;
using TPSite.Dto;
using TPSite.EntityFrameworkCore;
using TPSite.IService;
using TPSite.Tools.Extensions;

namespace TPSite.Service
{
    public sealed class UserService : EfCoreRepositoryBase<User, UserDto, Guid>, IUserService
    {
        public override IQueryable<User> GetAllIncluding()
        {
            return GetAll()
                .Include(i => i.CreatorUser)
                .Include(i => i.DeleterUser);
        }

        public override async Task<UserDto> InsertAsync(UserDto entityDto)
        {
            if (entityDto != null)
            {
                //检查用户名是否存在
                bool r = await CheckUserNameDupAsync(entityDto.UserName);
                if (!r)
                {
                    await _dbContext.Users.AddAsync(Mapper.Map<User>(entityDto));
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"已存在name={entityDto.UserName}的用户");
                }
            }
            return entityDto;
        }

        public Task<bool> CheckUserNameDupAsync(string userName)
        {
            return AnyAsync(i => i.UserName == userName);
        }

        public Task<bool> CheckPhoneDupAsync(string mobile)
        {
            return AnyAsync(i => i.Mobile == mobile);
        }

        public Task<bool> CheckEmailDupAsync(string email)
        {
            return AnyAsync(i => i.Email == email);
        }

        public async Task<(LoginResults, UserDto)> CheckUserPasswordAsync(string userNameOrEmailOrPhone, string password)
        {
            var userDto = await GetUserByUserNameOrEmailOrMobileAsync(userNameOrEmailOrPhone);
            if (userDto != null)
            {
                if (userDto.Password.Equals((password.ToMd5() + userDto.Salt).ToMd5(), StringComparison.OrdinalIgnoreCase))
                {
                    return (LoginResults.Success, userDto);
                }
                else
                {
                    return (LoginResults.PassWordError, null);
                }
            }
            else
            {
                return (LoginResults.NotExist, null);
            }
        }

        public async Task<UserDto> GetUserByUserNameOrEmailOrMobileAsync(string userNameOrEmailOrMobile)
        {
            UserDto userDto;
            if (userNameOrEmailOrMobile.IsNumeric() && userNameOrEmailOrMobile.Length == 11)
            {
                userDto = await SingleOrDefaultAsync(i => i.Mobile == userNameOrEmailOrMobile && i.IsPhoneNumConfirmed);
            }
            else
            {
                userDto = await SingleOrDefaultAsync(i =>
                    i.UserName == userNameOrEmailOrMobile || i.Email == userNameOrEmailOrMobile && i.IsEmailConfirmed);
            }
            return userDto;
        }
    }
}

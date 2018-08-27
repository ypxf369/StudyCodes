using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo2UserService.Models;
using Demo2UserService.Service;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("userRegister")]
        public async Task<IActionResult> UserRegister(UserModel model)
        {
            if (model == null)
            {
                return BadRequest(nameof(model) + "为空");
            }
            var user = new User()
            {
                UserName = model.UserName,
                Address = model.Address,
                Mobile = model.Mobile
            };
            var id = await _userService.AddUserAsync(user);
            return Ok(id);
        }
    }
}
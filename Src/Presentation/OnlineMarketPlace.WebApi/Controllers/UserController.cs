using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineMarketPlace.Application.Helpers;
using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.WebApi.Helpers;
using OnlineMarketPlace.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace OnlineMarketPlace.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthorizeService _authorizeService;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService, IAuthorizeService authorizeService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _authorizeService = authorizeService;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll().Select(user => Mapper.Instance.ToUserViewModel(user));
            return Ok(users);
        }

        [HttpPost]
        [Authorize(new[] { Role.Admin })]
        public IActionResult Post([FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var user = Mapper.Instance.ToUser(userViewModel);
                user.Password = _userService.GeneratePassword();
                _userService.SendEmailWithPassword(user, _appSettings.SendEmailSettings);
                var savedUser = _userService.Insert(user);
                return Ok(Mapper.Instance.ToUserViewModel(savedUser));
            } 
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var user = Mapper.Instance.ToUser(userViewModel);
                var savedUser = _userService.Insert(user);
                return Ok(Mapper.Instance.ToUserViewModel(savedUser));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Authorize(new[] { Role.Admin })]
        public IActionResult Put([FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var user = Mapper.Instance.ToUser(userViewModel);
                var updatedUser = _userService.Update(user);
                return Ok(Mapper.Instance.ToUserViewModel(updatedUser));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("changePassword")]
        [Authorize]
        public IActionResult ChangePassword([FromBody] ChangePasswordViewModel changePassword)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = _authorizeService.Authenticate(changePassword.Email, changePassword.OldPassword);

            if (user == null)
                return BadRequest("Old password is incorrect");

            try
            {
                user.Password = PasswordHasher.Instance.Hash(changePassword.NewPassword);
                var updatedUser = _userService.Update(user);
                return Ok(Mapper.Instance.ToUserViewModel(updatedUser));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{userId}")]
        [Authorize(new[] { Role.Admin })]
        public IActionResult Delete(int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _userService.Delete(userId);
            return Ok();
        }
    }
}

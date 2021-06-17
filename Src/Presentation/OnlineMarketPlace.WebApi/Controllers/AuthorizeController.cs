using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.WebApi.Helpers;
using OnlineMarketPlace.WebApi.Models;
using WebApi.Models;
using WebApi.ViewModels;
using AuthorizeAttribute = OnlineMarketPlace.WebApi.Helpers.AuthorizeAttribute;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private IAuthorizeService _authorizeService;
        private AppSettings _appSettings;

        public AuthorizeController(IAuthorizeService authorizeService, IOptions<AppSettings> appSettings)
        {
            _authorizeService = authorizeService;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthorizeRequest model)
        {
            var user = _authorizeService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest("Username or password is incorrect");

            var jwtToken = _authorizeService.GenerateJwtToken(user, _appSettings.Key);
            var response = Mapper.Instance.ToUserViewModel(user, jwtToken);
            return Ok(response);
        }
    }
}

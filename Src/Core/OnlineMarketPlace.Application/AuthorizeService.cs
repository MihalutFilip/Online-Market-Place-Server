using Microsoft.IdentityModel.Tokens;
using OnlineMarketPlace.Application.Helpers;
using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineMarketPlace.Application
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IUserRepository _userRepository;

        public AuthorizeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);

            if (user == null)
                return null;  

            return PasswordHasher.Instance.Check(user.Password, password) ? user : null;
        }

        public string GenerateJwtToken(User user, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}

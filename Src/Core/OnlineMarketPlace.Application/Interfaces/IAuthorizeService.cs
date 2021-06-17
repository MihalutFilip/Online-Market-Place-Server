using OnlineMarketPlace.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Application.Interfaces
{
    public interface IAuthorizeService
    {
        User Authenticate(string email, string password);
        string GenerateJwtToken(User user, string secretKey);
    }
}

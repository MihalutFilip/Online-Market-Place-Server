using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Insert(User user);
        User Update(User user);
        void Delete(int id);
        string GeneratePassword();
        void SendEmailWithPassword(User user, SendEmailSettings settings);
    }
}

using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using OnlineMarketPlace.Application.Helpers;
using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;
using OnlineMarketPlace.Domain.Entities;
using System.Linq;

namespace OnlineMarketPlace.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User Insert(User user)
        {
            user.Password = PasswordHasher.Instance.Hash(user.Password);
            return _userRepository.Insert(user);
        }

        public User Update(User user)
        {
            user.Password = _userRepository.GetById(user.Id).Password;
            return _userRepository.Update(user);
        }

        public string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int length = 20;
            Random random = new Random();

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void SendEmailWithPassword(User user, SendEmailSettings settings)
        {
            var message = new MimeMessage();
            BodyBuilder bodyBuilder = new BodyBuilder();

            bodyBuilder.TextBody = "Hello " + user.Username + ", this is your password account: " + user.Password;
            message.From.Add(MailboxAddress.Parse(settings.Email));
            message.To.Add(MailboxAddress.Parse(user.Email));
            message.Subject = "Password account";
            message.Body = bodyBuilder.ToMessageBody();

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect(settings.SmtpServer, settings.Port, true);
                smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                smtpClient.Authenticate(settings.Email, settings.Password);
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
            }
        }
    }
}

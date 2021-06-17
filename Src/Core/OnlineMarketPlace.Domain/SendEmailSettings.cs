using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Domain.Entities
{
    public class SendEmailSettings
    {
        public string Email { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}

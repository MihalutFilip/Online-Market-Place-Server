using OnlineMarketPlace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class AppSettings
    {
        public string Key { get; set; }
        public SendEmailSettings SendEmailSettings { get; set; }
    }
}

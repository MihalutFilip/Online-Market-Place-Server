using OnlineMarketPlace.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.WebApi.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string JwtToken { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public string ColorCode { get; set; }
    }
}

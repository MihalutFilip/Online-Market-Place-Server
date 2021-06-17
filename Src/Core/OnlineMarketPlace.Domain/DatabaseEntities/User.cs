using OnlineMarketPlace.Domain.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMarketPlace.Domain
{
    public class User : Entity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ColorCode { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Message> MessagesSend { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
    }
}

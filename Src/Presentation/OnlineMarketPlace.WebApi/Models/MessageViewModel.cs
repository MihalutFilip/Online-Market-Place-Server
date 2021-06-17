using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.WebApi.Models
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public UserViewModel Sender { get; set; }
        public int SenderId { get; set; }
        public UserViewModel Receiver { get; set; }
        public int ReceiverId { get; set; }
    }
}

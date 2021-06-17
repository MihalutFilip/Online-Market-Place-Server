using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Domain.DatabaseEntities
{
    public class Message : Entity
    {
        public string Content { get; set; }
        public DateTime SendTime { get; set; }

        public User Sender { get; set; }
        public int SenderId { get; set; }

        public User Receiver { get; set; }
        public int ReceiverId { get; set; }
    }
}

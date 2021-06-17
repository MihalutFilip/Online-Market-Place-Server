using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.WebApi.Helpers;
using OnlineMarketPlace.WebApi.Models;

namespace OnlineMarketPlace.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageController(IMessageService messageService, IHubContext<MessageHub> hubContext)
        {
            _messageService = messageService;
            _hubContext = hubContext;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var user = (User) HttpContext.Items["User"];
            var messages = _messageService.GetAllByUser(user.Id).Select(message => Mapper.Instance.ToMessageViewModel(message));
            return Ok(messages);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insert(MessageViewModel message)
        {
            var addedMessage = _messageService.Insert(Mapper.Instance.ToMessage(message));
            _hubContext.Clients.All.SendAsync("MessageReceived", message);
            return Ok(Mapper.Instance.ToMessageViewModel(addedMessage));
        }
    }
}

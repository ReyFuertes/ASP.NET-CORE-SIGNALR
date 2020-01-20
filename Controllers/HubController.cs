using Api.Models;
using Api.Services;
using ApiProj.Hubs;
using ApiProj.Models;
using ApiProj.Repository;
using ApiProj.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiProj.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private readonly IChatMessageRepository _chatRepo;
        private readonly IHubContext<ChatHub> _hub;
        public HubController(IChatMessageRepository chatRepo, IHubContext<ChatHub> hub)
        {
            _hub = hub;
            _chatRepo = chatRepo;
        }

        [HttpGet("messages")]
        public async Task<IActionResult> GetMessages()
        {
            try
            {
                return Ok(await this._chatRepo.GetMessages());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody]ChatMessage chat)
        {
            try
            {
                chat.SenderName = User.Identity.Name;
                chat.UserId = Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault().Value);
                chat.Guid = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault().Value;
                chat.SentAt = DateTime.Now;
                await _hub.Clients.All.SendAsync("Notification", chat);

                await this._chatRepo.SaveMessage(chat);
   
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

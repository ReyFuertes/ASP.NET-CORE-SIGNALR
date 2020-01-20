using Api.Models;
using ApiProj.Hubs;
using ApiProj.Models;
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
       
        public HubController(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }
        private readonly IHubContext<ChatHub> _hub;

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody]ChatMessage chat)
        {
            try
            {
                chat.SenderName = User.Identity.Name;
                chat.Guid = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault().Value;
                await _hub.Clients.All.SendAsync("Notification", chat);

                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

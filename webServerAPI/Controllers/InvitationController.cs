using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using System.Text.Json.Nodes;

namespace webServerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class invitationsController : ControllerBase
{
    private static InvitationService _invitationService;

    public invitationsController()
    {
        _invitationService = new InvitationService();
    }
    // POST api/<invitationController>
    [HttpPost]
    public IActionResult Post([Bind("From, To, Server")] Invitation invitation)
    {
        if(_invitationService.SendInvitation(invitation) == false)
        {
            return BadRequest();
        }
        return NoContent();
    }
}

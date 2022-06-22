using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using System.Text.Json.Nodes;

namespace webServerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
//controller for the Invitation model

public class invitationsController : ControllerBase
{
    private static IInvitationService _invitationService;

    public invitationsController()
    {
        _invitationService = new InvitationDbService();
    }
    // POST api/invitations
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

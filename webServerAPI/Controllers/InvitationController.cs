using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using System.Text.Json.Nodes;

namespace webServerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvitationController : ControllerBase
{
    private static InvitationService _invitationService;

    public InvitationController()
    {
        _invitationService = new InvitationService();
    }
    // POST api/<InvitationController>
    [HttpPost]
    public void Post([Bind("From, To, Server")] Invitation invitation)
    {
        _invitationService.SendInvitation(invitation);
    }
}

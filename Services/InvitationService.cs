using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Domain;
namespace Services
{
    public class InvitationService
    {
        ContactService contactService = new ContactService();
        public void SendInvitation(Invitation invitation)
        {
            Contact contact = new Contact();
            contact.Id = invitation.From;
            contact.Server = invitation.Server;
            contactService.Create(invitation.To, contact);
        }
    }
}

using Domain;
namespace Services
{
    public class InvitationService : IInvitationService
    {
        ContactService contactService = new ContactService();
        public bool SendInvitation(Invitation invitation)
        {
            try
            {
                //create a new contact acording to the info from invitation
                Contact contact = new Contact();
                contact.Id = invitation.From;
                contact.Name = invitation.From;
                contact.Server = invitation.Server;
                contactService.Create(invitation.To, contact);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

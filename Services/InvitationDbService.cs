using Domain;
namespace Services
{
    public class InvitationDbService : IInvitationService
    {
        IContactService contactService = new ContactDbService();
        public bool SendInvitation(Invitation invitation)
        {
            try
            {
                //create a new contact acording to the info from invitation
                Contact contact = new Contact();
                contact.Id = invitation.From;
                contact.Name = invitation.From;
                contact.Server = invitation.Server;
                return contactService.Create(invitation.To, contact);
                //return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

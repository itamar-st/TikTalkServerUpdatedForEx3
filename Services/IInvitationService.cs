using Domain;
namespace Services
{
    public interface IInvitationService
    {
        //open a conversation with invitation.from. on success return true, othewise false
        public bool SendInvitation(Invitation invitation);

    }
}

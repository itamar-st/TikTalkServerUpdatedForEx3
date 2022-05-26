using Domain;
namespace Services
{
    public interface IInvitationService
    {
        public bool SendInvitation(Invitation invitation);

    }
}

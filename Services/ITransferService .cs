using Domain;

namespace Services
{
    public interface ITransferService
    {
        public bool SendMessage(Transfer transfer);
    }
}

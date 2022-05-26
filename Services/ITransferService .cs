using Domain;

namespace Services
{
    public interface ITransferService
    {
        //update the chat with the trasfer.from
        public bool onMessageArrival(Transfer transfer);
    }
}

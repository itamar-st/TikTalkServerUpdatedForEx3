using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public class TransferDbService : ITransferService
    {
        IMessageService messageService = new MessageDbService();
        IContactService contactService = new ContactDbService();
       public bool onMessageArrival(Transfer transfer)
        {
            try
            {
                // add a message to the chat with the contact ( from )
                JsonObject contentJson = new JsonObject();
                contentJson.Add("content", transfer.Content);
                // false because we got the message
                if(messageService.Create(transfer.To, transfer.From, contentJson, false) == false)
                {
                    return false;
                };
                contactService.EditLastMsg(transfer.To, transfer.From, contentJson["content"].ToString(), DateTime.Now.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

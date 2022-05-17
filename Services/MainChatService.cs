using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Services
{
    public class MainChatService
    {
        public static UserService userService;
        public static ContactService contactService;
        public static ChatService chatService;

        public static User currentUser = null;
        public static Contact currentContact = null;
        public static Chat currentChat = null;

        public Contact GetCurrentContact()
        {//TODO: check if null
            return currentContact;
        }
        public Chat GetCurrentChat()
        {
            return currentChat;
        }
        public User GetCurrentUser()
        {
            return currentUser;
        }


        public void SetCurrentContact(int contactId)
        {
            currentContact = contactService.Get(contactId);
        }
        public void SetCurrentChat(int contactId)
        {
            currentChat = chatService.Get(contactId);
        }
        public void SetCurrentUser(int userId)
        {
            currentUser = userService.Get(userId);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public class TransferService
    {
        MessageService messageService = new MessageService();
       public bool SendMessage(Transfer transfer)
        {
            try
            {
                Contact currentContact = new Contact();
                JsonObject contentJson = new JsonObject();
                contentJson.Add("content", transfer.Content);
                // false because we got the message
                messageService.Create(transfer.To, transfer.From, contentJson, false);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

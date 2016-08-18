using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;
using DevStore.Domain;
using DevStore.Infra.DataContexts;
using Microsoft.AspNet.SignalR;
using User = Business.User;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        public ResponseObject EnterChat(string name)
        {
            var resp = User.Instance.RegisterNewUser(name);
            return resp;
        }

        public ResponseObject SendMessage(string text,int id,string userName)
        {
            var resp = Messages.Instance.NewMessageFromUser(text,id);
            
            Clients.All.newMessage(resp.Object, userName);

            return resp;
        }

        public List<Message> GetRecentMessages()
        {
            var resp = Messages.Instance.GetRecentMessages();

            return resp;
        }
    }
}
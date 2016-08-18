using System.Collections.Generic;
using DevStore.Domain;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using User = DevStore.Application.User;
using DevStore.Application;

namespace WebChat.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        public ResponseObject EnterChat(string name)
        {
            var resp = User.Instance.RegisterNewUser(name);

            return resp;
        }

        public ResponseObject SendMessage(string text, int id, string userName)
        {
            var resp = Messages.Instance.NewMessageFromUser(text, id);

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
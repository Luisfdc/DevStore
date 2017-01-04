using System.Collections.Generic;
using DevStore.Domain;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DevStore.Application;

namespace WebChat.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        private UserApplication _userApplication;
        private MessagesApplication _messagesApplication;

        public ChatHub(UserApplication userApplication, MessagesApplication messagesApplication)
        {
            _userApplication = userApplication;
            _messagesApplication = messagesApplication;
        }

        public ResponseObject EnterChat(string name)
        {
            var resp = _userApplication.RegisterNewUser(name);

            return resp;
        }

        public ResponseObject SendMessage(string text, int id, string userName)
        {
            var resp = _messagesApplication.NewMessageFromUser(text, id);

            Clients.All.newMessage(resp.Object, userName);

            return resp;
        }

        public List<Message> GetRecentMessages()
        {
            var resp = _messagesApplication.GetRecentMessages();
            return resp;
        }
    }
}
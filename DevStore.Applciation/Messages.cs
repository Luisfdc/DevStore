using System;
using System.Collections.Generic;
using System.Linq;
using DevStore.Domain;
using DevStore.Domain.Interfaces;

namespace DevStore.Application
{
    public class MessagesApplication : Singleton<MessagesApplication>
    {
        private IMessageRepository messageRepository;

        private MessagesApplication(IMessageRepository _messageRepository)
        {
            messageRepository = _messageRepository;
        }

        public ResponseObject NewMessageFromUser(string text, int id)
        {

            try
            {
                Message message = new Message(text,id);
                messageRepository.Add(message);
                return new ResponseObject(true, "Message inserida com sucesso!", message);
            }
            catch (Exception)
            {
                return new ResponseObject(false, "Erro ao tentar salvar Message!");
            }

        }

        public List<Message> GetRecentMessages()
        {
                return messageRepository.Get()
                    .OrderByDescending(a => a.CreateDate)
                    .Take(50).ToList()
                    .OrderBy(a => a.CreateDate)
                    .ToList();
        }
    }
}

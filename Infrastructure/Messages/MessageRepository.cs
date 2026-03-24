using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.IO;
using System.Web;

namespace Project.Infrastructure
{
    public class MessageRepository
    {

        private readonly IRepository<MessageModel> _storage;

        public MessageRepository(IRepository<MessageModel> storage)
        {
            _storage = storage;
        }

        public List<MessageModel> GetMessages(string sortOrder, int pageNumber, out int totalPages, int pageSize = 5) {
            var messages = _storage.GetAll();
            if (messages == null)
            {
                totalPages = 0;
                return new List<MessageModel>();
            }

            messages = MessageSorter.Sort(messages, sortOrder);
            
            totalPages = (int)Math.Ceiling(messages.Count / (double)pageSize);
            return MessagePaginator.Take(messages, pageSize, pageNumber);
        }

        public void Add(MessageModel item) { 
            _storage.Add(item);
        }
    }
}

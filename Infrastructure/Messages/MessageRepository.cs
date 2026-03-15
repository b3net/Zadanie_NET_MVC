using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Project.Infrastructure
{
    public class MessageRepository : RepositoryBase<MessageModel>
    {
        private static readonly string DefaultPath = Path.Combine(
            HttpRuntime.AppDomainAppPath, 
            "App_Data", 
            "messages.json"
        );

        public MessageRepository() : base(DefaultPath)
        {
        }

        public List<MessageModel> GetMessages(string sortOrder, int pageNumber, out int totalPages, int pageSize = 5) {
            var messages = GetAll();
            if (messages == null)
            {
                totalPages = 0;
                return new List<MessageModel>();
            }

            messages = MessageSorter.Sort(messages, sortOrder);
            
            totalPages = (int)Math.Ceiling(messages.Count / (double)pageSize);
            return MessagePaginator.Take(messages, pageSize, pageNumber);

        }
    }
}

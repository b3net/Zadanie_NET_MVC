using System.Collections.Generic;
using System.Linq;
using Project.Models;

namespace Project.Infrastructure
{
    public static class MessagePaginator
    {
        public static List<MessageModel> Take(IEnumerable<MessageModel> messages, int pageSize, int pageNumber)
        {
            if (messages == null) return new List<MessageModel>();

            return messages.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

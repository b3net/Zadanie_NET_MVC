using System.Collections.Generic;
using System.Linq;
using Project.Models;

namespace Project.Infrastructure
{
    public static class MessageSorter
    {
        public static List<MessageModel> Sort(IEnumerable<MessageModel> messages, string sortOrder)
        {
            if (messages == null) return new List<MessageModel>();

            switch (sortOrder)
            {
                case "date_desc":
                    return messages.OrderByDescending(m => m.CreatedAt).ToList();
                case "date":
                    return messages.OrderBy(m => m.CreatedAt).ToList();
                case "first_name":
                    return messages.OrderBy(m => m.FirstName).ToList();
                case "first_name_desc":
                    return messages.OrderByDescending(m => m.FirstName).ToList();
                case "last_name":
                    return messages.OrderBy(m => m.LastName).ToList();
                case "last_name_desc":
                    return messages.OrderByDescending(m => m.LastName).ToList();
                case "email":
                    return messages.OrderBy(m => m.Email).ToList();
                case "email_desc":
                    return messages.OrderByDescending(m => m.Email).ToList();
                default:
                    return messages.OrderByDescending(m => m.CreatedAt).ToList();
            }
        }
    }
}

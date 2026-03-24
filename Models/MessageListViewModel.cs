using System.Collections.Generic;
namespace Project.Models
{
    public class MessageListViewModel
    {
        public List<MessageModel> Messages { get; set; }

        public PaginationViewModel Pagination { get; set; }
 
        public string CurrentSort { get; set; }
        public string FirstNameSortParm { get; set; }
        public string LastNameSortParm { get; set; }
        public string EmailSortParm { get; set; }
        public string DateSortParm { get; set; }
    }
}
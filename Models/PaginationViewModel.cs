using System.Collections.Generic;
namespace Project.Models
{
    public class PaginationViewModel
    {
        private readonly string _action;
        public PaginationViewModel(string action = "List") {
            _action = action;
        }

        public string PaginationAction { get { return _action; } }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
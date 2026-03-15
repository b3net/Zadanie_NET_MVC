using Project.Resources;
using Project.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }

        [NotBlank(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(AppResources), Name = "FirstName")]
        public string FirstName { get; set; }

        [NotBlank(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(AppResources), Name = "LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "RequiredField")]
        [StrictEmail(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "InvalidEmail")]
        [Display(ResourceType = typeof(AppResources), Name = "Email")]
        public string Email { get; set; }

        [AllowHtml]
        [NotBlank(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "MessageLength")]
        [Display(ResourceType = typeof(AppResources), Name = "Message")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

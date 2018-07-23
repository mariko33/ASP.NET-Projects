using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using SnippySystem.Models.EntityModels;

namespace SnippySystem.Models.ViewModels.Comments
{
    public class AddCommentViewModel
    {
      
        public int SnippetId { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "The content is required")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

     
    }
}
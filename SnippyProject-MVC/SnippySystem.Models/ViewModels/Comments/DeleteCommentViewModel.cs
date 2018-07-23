using System;
using SnippySystem.Models.EntityModels;

namespace SnippySystem.Models.ViewModels.Comments
{
    public class DeleteCommentViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreationTime { get; set; }
        public string Content { get; set; }
        public string SnippetTitle { get; set; }
        public int SnippetId { get; set; }
        
    }
}
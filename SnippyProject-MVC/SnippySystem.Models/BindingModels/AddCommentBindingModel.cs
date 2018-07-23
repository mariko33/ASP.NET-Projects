using System.ComponentModel.DataAnnotations;

namespace SnippySystem.Models.BindingModels
{
    public class AddCommentBindingModel
    {
        public int SnippetId { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }
        
    }
}
using System.Collections.Generic;
using SnippySystem.Models.EntityModels;

namespace SnippySystem.Models.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
           // this.Snippets = new HashSet<Snippet>();
            this.Comments = new HashSet<Comment>();
            this.Labels = new HashSet<Label>();
        }

        //public ICollection<Snippet> Snippets { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Label> Labels { get; set; }
    }
}
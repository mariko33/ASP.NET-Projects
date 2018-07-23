using System.Collections.Generic;
using SnippySystem.Models.EntityModels;

namespace SnippySystem.Models.ViewModels.Labels
{
    public class LabelViewModel
    {
        
            public LabelViewModel()
            {
                this.Snippets = new HashSet<Snippet>();
            }

            public int Id { get; set; }
            public string Text { get; set; }
            public  ICollection<Snippet> Snippets { get; set; }
        
    }
}
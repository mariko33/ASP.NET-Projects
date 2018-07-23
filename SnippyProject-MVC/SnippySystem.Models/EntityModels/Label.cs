using System.Collections.Generic;

namespace SnippySystem.Models.EntityModels
{
    public class Label
    {
        public Label()
        {
            this.Snippets = new HashSet<Snippet>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Snippet> Snippets { get; set; }
    }
}
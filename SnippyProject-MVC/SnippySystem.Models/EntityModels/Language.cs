using System.Collections.Generic;

namespace SnippySystem.Models.EntityModels
{
    public class Language
    {
        public Language()
        {
            this.Snippets = new HashSet<Snippet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Snippet> Snippets { get; set; }
    }
}
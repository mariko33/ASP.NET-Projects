using System.Collections.Generic;

namespace SnippySystem.Models.EntityModels
{
    public class UserLogged
    {
        public UserLogged()
        {
            this.Snippets = new HashSet<Snippet>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public virtual ICollection<Snippet> Snippets { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
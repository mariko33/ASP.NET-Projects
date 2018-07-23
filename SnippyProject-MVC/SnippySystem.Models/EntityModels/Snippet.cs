using System;
using System.Collections.Generic;

namespace SnippySystem.Models.EntityModels
{
    public class Snippet
    {
        public Snippet()
        {
            this.Labels = new HashSet<Label>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public virtual Language Language { get; set; }
        public virtual UserLogged Author { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual ICollection<Label> Labels { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
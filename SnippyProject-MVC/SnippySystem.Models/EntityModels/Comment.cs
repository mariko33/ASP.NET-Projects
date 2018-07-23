using System;

namespace SnippySystem.Models.EntityModels
{
    public class Comment
    {
        public int Id { get; set; }
        public virtual UserLogged Author { get; set; }
        public DateTime CreationTime { get; set; }
        public string Content { get; set; }
        public virtual Snippet Snippet { get; set; }
    }
}
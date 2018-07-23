using SnippySystem.Data;

namespace SnippySystem.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = new SnippySystemContext();

        }

        protected SnippySystemContext Context { get; }
    }
}
using System.Linq;
using AutoMapper;
using SnippySystem.Models.EntityModels;
using SnippySystem.Models.ViewModels.Home;
using SnippySystem.Models.ViewModels;

namespace SnippySystem.Services
{
    public class SnippetServices:Service
    {
        public SnippetViewModel GetSnippetDetails(int id)
        {

            Snippet snippet = this.Context.Snippets.FirstOrDefault(s => s.Id == id);
            SnippetViewModel snippetVm = Mapper.Map<Snippet, SnippetViewModel>(snippet);

            return snippetVm;
        }
    }
}
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using AutoMapper;
using SnippySystem.Models.EntityModels;
using SnippySystem.Models.ViewModels.Home;
using SnippySystem.Models.ViewModels.Manage;

namespace SnippySystem.Services
{
    public class HomeService:Service
    {
        public HomeIndexViewModel GetIndexViewModel()
        {
            //List<Snippet> snippets = this.Context.Snippets.OrderByDescending(s => s.CreationTime).Take(5).ToList();
            List<Comment> comments = this.Context.Comments.OrderByDescending(c => c.CreationTime).Take(5).ToList();
            List<Label> labels = this.Context.Labels.OrderByDescending(l => l.Snippets.Count).ToList();
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Comments = comments;
            //model.Snippets = snippets;
            model.Labels = labels;

            return model;

        }

        public ICollection<SnippetViewModel> GetAllSnippets()
        {
            var allSnippets = this.Context.Snippets.ToList();
            ICollection<SnippetViewModel> allSnippetViewModels =
                Mapper.Map<ICollection<Snippet>, ICollection<SnippetViewModel>>(allSnippets);
            return allSnippetViewModels;
        }
    }
}
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using SnippySystem.Models.EntityModels;
using SnippySystem.Models.ViewModels.Comments;
using SnippySystem.Models.ViewModels.Home;
using SnippySystem.Models.ViewModels.Labels;

namespace SnippySystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMapping();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMapping()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Snippet,SnippetViewModel>();
                expression.CreateMap<Comment, DeleteCommentViewModel>()
                    .ForMember(c => c.UserName, opt => opt.MapFrom(cm => cm.Author.User.Name))
                    .ForMember(c => c.SnippetTitle, opt => opt.MapFrom(cm => cm.Snippet.Title))
                    .ForMember(c => c.SnippetId, opt => opt.MapFrom(cm => cm.Snippet.Id));
                expression.CreateMap<Label, LabelViewModel>();



            });
        }
    }
}
//public int Id { get; set; }
//public string UserName { get; set; }
//public DateTime CreationTime { get; set; }
//public string Content { get; set; }
//public string SnippetTitle { get; set; }
//public int SnippetId { get; set; }

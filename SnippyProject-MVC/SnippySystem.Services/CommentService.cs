using System;
using System.Linq;
using System.Net;
using AutoMapper;
using SnippySystem.Models.BindingModels;
using SnippySystem.Models.EntityModels;
using SnippySystem.Models.ViewModels.Comments;


namespace SnippySystem.Services
{
    public class CommentService:Service
    {
        public void AddComment(AddCommentBindingModel model)
        {
            Snippet snippet = this.Context.Snippets.FirstOrDefault(s => s.Id == model.SnippetId);
            DateTime currentTime=DateTime.Now;
            UserLogged author = this.Context.UserLoggeds.FirstOrDefault(u => u.User.Id==model.UserId);
            string content = model.Content;

            Comment comment=new Comment()
            {
                Author = author,
                Content = content,
                CreationTime = currentTime,
                Snippet = snippet
            };

            this.Context.Comments.Add(comment);
            this.Context.SaveChanges();

        }

        public AddCommentViewModel GetAddComment(int id)
        {
            AddCommentViewModel model = new AddCommentViewModel
            {
                SnippetId = id
            };

            return model;
        }

        public DeleteCommentViewModel GetDeleteVm(int id)
        {
            Comment comment = this.Context.Comments.FirstOrDefault(c => c.Id == id);
            DeleteCommentViewModel modelComment = Mapper.Map<Comment, DeleteCommentViewModel>(comment);
            return modelComment;
        }

        public void DeleteComment(int modelId)
        {
            Comment targetComment = this.Context.Comments.FirstOrDefault(c => c.Id == modelId);
            this.Context.Comments.Remove(targetComment);
            this.Context.SaveChanges();
        }
    }
}
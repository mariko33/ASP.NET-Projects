using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SnippySystem.Models.EntityModels;

namespace SnippySystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SnippySystem.Data.SnippySystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SnippySystem.Data.SnippySystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            if (!context.Roles.Any(role => role.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("User");
                manager.Create(role);

            }

            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);

            }

            context.Languages.AddOrUpdate(l =>
                l.Name,
                new Language()
                {
                    Name = "C#"
                },
                new Language()
                {
                    Name = "JavaScript"
                },
                new Language()
                {
                    Name = "Python"
                },
                new Language()
                {
                    Name = "CSS"
                },
                new Language()
                {
                    Name = "SQL"
                },
                new Language()
                {
                    Name = "PHP"
                });

            context.Labels.AddOrUpdate(l =>
                l.Text,
                new Label()
                {
                    Text = "bug"
                },
                new Label()
                {
                    Text = "funny"
                },
                new Label()
                {
                    Text = "jquery"
                },
                new Label()
                {
                    Text = "mysql"
                },
                new Label()
                {
                    Text = "useful"
                },
                new Label()
                {
                    Text = "web"
                },
                new Label()
                {
                    Text = "geometry"
                },
                new Label()
                {
                    Text = "back-end"
                },
                new Label()
                {
                    Text = "front-end"
                },
                new Label()
                {
                    Text = "games"
                });

            context.Snippets.AddOrUpdate(
                s => s.Title,
                new Snippet
                {
                    Title = "Ternary Operator Madness",
                    Description = "This is how you DO NOT user ternary operators in C#!",
                    Code = "bool X=Glob.UserIsAdmin ? true : false;",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Geri"),
                    CreationTime = new DateTime(2017, 10, 26, 17, 20, 33),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "C#"),
                    Labels = new List<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "funny")
                    }

                },
                new Snippet()
                {
                    Title = "Points Around A Circle For GameObject Placement",
                    Description =
                        "Determine points around a circle which can be used to place elements around a central point",
                    Code = "private Vector3 DrawCircle(float centerX, float centerY, float radius, " +
                           "float totalPoints, float currentPoint)" +
                           "{" +
                           "float ptRatio = currentPoint / totalPoints;" +
                           "float pointX = cnterX + (Mathf.Cos(ptRatio * 2 * Mathf.PI)) * radius;" +
                           "float pointY = centerY + (Mathf.Sin(ptRatio * 2 * Mathf.PI)) * radius;" +
                           "" +
                           "vector3 panelCenter = new Vector3(pointX, pointY, 0.0f);" +
                           "" +
                           "return panelCenter;" +
                           "}",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Geri"),
                    CreationTime = new DateTime(2017, 10, 26, 20, 15, 30),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "C#"),
                    Labels = new List<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "geometry"),
                        context.Labels.FirstOrDefault(l => l.Text == "games")
                    }
                },
                new Snippet()
                {
                    Title = "forEach. How to break?",
                    Description = "Array.prototype.forEach You can't break forEach. So use 'some' or 'every'. " +
                                  "Array.prototype.some some is pretty much the same as forEach but it break when the " +
                                  "callback returns true. Array.prototype.every every is almost identical to some except" +
                                  "it's expecting false to break the loop.",
                    Code = "var ary = ['JavaScript', 'Java', 'CoffeeScript', 'TypeScript'];" +
                           "ary.some(function(value, index, _ary){" +
                           "console.log(index + '; ' + value);" +
                           "return value == 'CofeeScript';" +
                           "})",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Geri"),
                    CreationTime = new DateTime(2017, 10, 27, 10, 53, 20),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "JavaScript"),
                    Labels = new List<Label>()
                    {
                        context.Labels.FirstOrDefault(l => l.Text == "jquery"),
                        context.Labels.FirstOrDefault(l => l.Text == "useful"),
                        context.Labels.FirstOrDefault(l => l.Text == "web"),
                        context.Labels.FirstOrDefault(l => l.Text == "front-end")
                    }


                },
                new Snippet()
                {
                    Title = "Numbers only in an input field",
                    Description = "Method allowing only numbers (positive/negative/with commas or decimal points)" +
                                  "in a field",
                    Code = "$('input').keypress(function(event){" +
                           "var charCode = (event.which) ? event.which : window.event.keyCode;" +
                           "if(charCode <= 13){return true;}" +
                           "else{var keyChar = String.fromCharCode(charCode);" +
                           "var regex = new RegExp('[0-9,.-]')" +
                           "return regex.test(keyChar);}" +
                           "})",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Geri"),
                    CreationTime = new DateTime(2017, 10, 28, 09, 00, 56),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "JavaScript"),
                    Labels = new List<Label>()
                    {

                        context.Labels.FirstOrDefault(l => l.Text == "web"),
                        context.Labels.FirstOrDefault(l => l.Text == "front-end")
                    }


                },
                new Snippet()
                {
                    Title = "Create a linl directly in an SQL query",
                    Description = "That's how you create links - directly in the SQL!",
                    Code = "SELECT DISTINCT b.ID," +
                           "concat('<button type = 'button' onclick='DeleteContact(', cast(b.Id as char), >" +
                           "Delete...</button>')' ') as linkDelete" +
                           "FROM tblContact b" +
                           "WHERE ....",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Admin"),
                    CreationTime = new DateTime(2017, 10, 30, 11, 20, 00),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "SQL"),
                    Labels = new List<Label>()
                    {

                        context.Labels.FirstOrDefault(l => l.Text == "bug"),
                        context.Labels.FirstOrDefault(l => l.Text == "funny"),
                        context.Labels.FirstOrDefault(l => l.Text == "mysql")
                    }


                },
                new Snippet()
                {
                    Title = "Reverse a String",
                    Description = "Almost not worth having a function for ...",
                    Code = "def reverseString(s):'Reverses a string given to il.'" +
                           "return s[::-1]",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Admin"),
                    CreationTime = new DateTime(2017, 10, 26, 09, 35, 13),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "Python"),
                    Labels = new List<Label>()
                    {

                        context.Labels.FirstOrDefault(l => l.Text == "useful")

                    }


                },
                new Snippet()
                {
                    Title = "Pure CSS Text Gardients",
                    Description = "This code describes how to create text gradients only pure CSS",
                    Code = "/* CSS text gradients */" +
                           "h2[data -text]{" +
                           "position: relative;" +
                           "}" +
                           "h2[data-text]::after{" +
                           "content: attr(data-text);" +
                           "z-index: 10;" +
                           "color: #e3e3e3;" +
                           "position: absolute;" +
                           "top: 0;" +
                           "left:0;" +
                           "-webkit-mask-image: -webkit-gradient(liner, left top, left bottom," +
                           "from(rgba(0,0,0,0)), color-stop(50%, rgba(0,0,0,1)), to(rgba(0,0,0,0)))" +
                           "}",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Admin"),
                    CreationTime = new DateTime(2017, 10, 22, 19, 26, 42),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "CSS"),
                    Labels = new List<Label>()
                    {

                        context.Labels.FirstOrDefault(l => l.Text == "web"),
                        context.Labels.FirstOrDefault(l => l.Text == "front-end")

                    }



                },
                new Snippet()
                {
                    Title = "Check for a Boolean value in JS",
                    Description = "How to check a Boolean value - the wrong bat funny way :D",
                    Code = "var b =true;" +
                           "if(b.toString().length < 5){//..}",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Admin"),
                    CreationTime = new DateTime(2017, 10, 22, 05, 30, 04),
                    Language = context.Languages.FirstOrDefault(l => l.Name == "JavaScript"),
                    Labels = new List<Label>()
                    {

                        context.Labels.FirstOrDefault(l => l.Text == "funny"),


                    }



                }

            );

            context.Comments.AddOrUpdate(c =>
                c.Content,
            new Comment()
            {
                Content = "Now that's really funny! I like it!",
                Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Admin"),
                CreationTime = new DateTime(2017, 10, 30, 11, 50, 38),
                Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Ternary Operator Madness"),

            },
                new Comment()
                {
                    Content = "Here, have my comment!",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Geri"),
                    CreationTime = new DateTime(2017, 11, 01, 15, 52, 42),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Ternary Operator Madness"),

                },
                new Comment()
                {
                    Content = "I didn't manage to comment first :(",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Geri"),
                    CreationTime = new DateTime(2017, 11, 02, 05, 30, 20),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Ternary Operator Madness"),

                },
                new Comment()
                {
                    Content = "That's why I love Pyton - everything is so simple!",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Geri"),
                    CreationTime = new DateTime(2017, 11, 27, 15, 28, 14),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Reverse a String"),

                },
                new Comment()
                {
                    Content = "I have always had roblems with Geometry in school. Thanks to you I can now do this " +
                              "without ever having to learn this damn subject",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Admin"),
                    CreationTime = new DateTime(2017, 10, 29, 15, 08, 42),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Points Around A Circle For GameObject Placement")

                },
                new Comment()
                {
                    Content = "Thank you. However, I think there must be a simpler way to do this. I can't figure it out now," +
                              "but I'll post it when I'm ready.",
                    Author = context.UserLoggeds.FirstOrDefault(u => u.User.Name == "Admin"),
                    CreationTime = new DateTime(2017, 11, 03, 12, 56, 20),
                    Snippet = context.Snippets.FirstOrDefault(s => s.Title == "Numbers only in an input field"),

                }

                );


        }
    }
}

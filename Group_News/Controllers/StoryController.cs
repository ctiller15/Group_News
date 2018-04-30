using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data.Entity;
using Group_News.Models;
using Group_News.ViewModels;
using Group_News.Context;

namespace Group_News.Controllers
{
    public class StoryController : ApiController
    {
        //view all stories
        [HttpGet]
        [Route ("api/stories")]
        public IEnumerable<Story> GetStories()
        {
            using(var db = new GroupNewsContext())
            {
                return db.Stories.Include(i => i.Category).Include(i => i.Author).OrderBy(o => o.Headline).ToList(); 
            }
        }


        [HttpGet]
        [Route("api/stories/{storyID}")]
        public IHttpActionResult GetOneStory(int storyID)
        {
            using (var db = new GroupNewsContext())
            {
                var query = db.Stories.SingleOrDefault(s => s.ID == storyID);
                return Ok(query);
            }
        }

        // POST: Have a user insert a story
        [HttpPost]
        [Route("api/stories")]
        public IHttpActionResult PostStory([FromBody]EnterStory StoryData)
        {
            using (var db = new GroupNewsContext())
            {
                var AllStories = db.Stories.Include(i => i.Author).Include(i => i.Category);
                
                // If author exists, save them.
                var author = db.Authors.SingleOrDefault(s => s.Name == StoryData.UserName);
                // Otherwise, create them.

                if(author == null)
                {
                    author = new Author
                    {
                        Name = StoryData.UserName
                    };
                    db.Authors.Add(author);
                    db.SaveChanges();
                }

                // Similar deal for category.
                var category = db.Categories.SingleOrDefault(s => s.Name == StoryData.Category);

                if(category == null)
                {
                    category = new Category
                    {
                        Name = StoryData.Category
                    };
                    db.Categories.Add(category);
                    db.SaveChanges();
                }

                // Then, create and save the post.
                var newPost = new Story
                {
                    Headline = StoryData.Headline,
                    Body = StoryData.Body,
                    CreationDate = DateTime.Now,
                    Author = author,
                    Category = category
                };

                db.Stories.Add(newPost);
                db.SaveChanges();

                return Ok(newPost);

            }

        }

    }
}

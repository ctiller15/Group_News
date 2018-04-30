using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Group_News.Models;
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
                return db.Stories.OrderBy(o => o.Headline).ToList(); 
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
    }
}

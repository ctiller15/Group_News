using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Group_News.Models;
using Group_News.Context;

namespace Group_News.Controllers
{
    public class CategoryController : ApiController
    {
        //view all categories
        [HttpGet]
        [Route("api/categories")]
        public IEnumerable<Category> GetCategories()
        {
            using (var db = new GroupNewsContext())
            {
                return db.Categories.OrderBy(o => o.Name).ToList();
            }
        }
    }
}

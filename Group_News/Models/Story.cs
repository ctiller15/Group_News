using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group_News.Models
{
    public class Story
    {
        public int ID { get; set; }
        public string Headline { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        public int? CategoryID { get; set; }
        public Category Category { get; set; }

        public int? AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
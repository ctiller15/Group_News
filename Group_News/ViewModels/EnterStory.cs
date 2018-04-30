using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group_News.ViewModels
{
    public class EnterStory
    {
        public string Headline { get; set; }
        public string Body { get; set; }
        public string UserName { get; set; }
        public string Category { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<PostModel> Posts { get; private set; }


        public HomeViewModel(IEnumerable<PostModel> posts)
        {
            Posts = posts;
        }
    }
}

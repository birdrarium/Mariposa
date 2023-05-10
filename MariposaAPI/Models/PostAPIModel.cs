using System;
using System.ComponentModel.DataAnnotations;

namespace MariposaAPI.Models
{
    public class PostAPIModel
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int UserId { get; set; }
        public UserAPIModel UserModel { get; set; }
        public string CreatedDate { get; set; }
        [Required]
        public string Content { get; set; }
        public string[]? Images { get; set; }
        //public string UserName { get; set; }


        public PostAPIModel(int PostId, int UserId, string Content, string CreatedDate)
        {
            this.PostId = PostId;
            this.UserId = UserId;
            Images = new string[] { };
            this.CreatedDate = CreatedDate;
            this.Content = Content;
            //this.UserName = UserModel.UserName;
        }

    }
}

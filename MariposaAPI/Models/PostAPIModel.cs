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
        //public UserAPIModel UserAPIModel { get; set; }
        //public string? UserName { get; set; }
        //public string? PhotoURL { get; set; }
        public string CreatedDate { get; set; }
        public string[]? Images { get; set; }
        [Required]
        public string Content { get; set; }

        public PostAPIModel(int PostId, int UserId, string Content, string CreatedDate)
        //public PostAPIModel (int PostId, int UserId, string Content, string CreatedDate, string userName, string photoURL)
        {
            this.PostId = PostId;
            this.UserId = UserId;
            Images = new string[] { };
            this.CreatedDate = CreatedDate;
            this.Content = Content;
            //this.UserName = userName;
            //this.PhotoURL = photoURL;
            //this.UserName = "";
            //this.PhotoURL = "";
        }

    }
}

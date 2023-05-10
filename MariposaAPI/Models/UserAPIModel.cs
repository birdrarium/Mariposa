using System;
using System.Collections.Generic;
namespace MariposaAPI.Models
{
    public class UserAPIModel
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PhotoURL { get; set; }
        //public IList<PostAPIModel>? Posts { get; set; }

        public UserAPIModel(int userId, string userName, string photoUrl)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.PhotoURL = photoUrl;
        }
    }
}

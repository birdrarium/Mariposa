using System;
namespace MariposaAPI.Models
{
    public class UserAPIModel
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PhotoURL { get; set; }


        public UserAPIModel(int userId, string userName, string photoUrl)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.PhotoURL = photoUrl;
        }
    }
}

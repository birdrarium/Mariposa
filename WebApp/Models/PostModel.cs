using System;
using Newtonsoft.Json;

namespace WebApp.Models
{
    public class PostModel
    {

        public int PostId { get; set; }
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
        public string UserName { get; private set; }
        [JsonProperty("CreatedDate")]
        public string _createdDate { get; set; }
        public string[]? Images { get; set; }
        public string Content { get; set; }

        public DateTime CreatedDateTime => DateTime.Parse(_createdDate);


        public PostModel()
        {
            //this.UserName = UserModel.UserName;
        }
    }
}

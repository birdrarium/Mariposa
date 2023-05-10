using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using MariposaAPI.Models;
using Microsoft.Extensions.Logging;

namespace MariposaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostAPIController : Controller
    {
        private readonly MySqlConnection database;

        public PostAPIController(MySqlConnection mySql)
        {
            database = mySql;
        }

        [HttpGet]
        public List<PostAPIModel> GetAll()
        {
            var metadata = new List<PostAPIModel>();
            var query = @"SELECT p.PostId, p.UserId, p.Content, p.CreatedDate, u.UserId, u.UserName, u.PhotoURL FROM posts p INNER JOIN users u ON p.UserId = u.UserId ORDER BY CreatedDate DESC;";

            database.Open();

             var result = database.Query<PostAPIModel, UserAPIModel, PostAPIModel>(query, map: (post, user) => {
                post.UserModel = user;
                metadata.Add(post);
                return post;
            }, splitOn: "UserId");

            database.Close();

            return metadata;
        }

        [HttpGet("{id}")]
        public ActionResult<PostAPIModel> GetById(int id)
        {
            try
            {
                var query = "SELECT * FROM posts WHERE PostId = @id";
                database.Open();
                var result = database.Query<PostAPIModel>(query, new { id });
                database.Close();
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<PostAPIModel> Post([FromBody] PostAPIModel post)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var query =
                @"INSERT INTO Mariposa.posts (UserId, Content, CreatedDate)
                VALUES (@UserId, @Content, @CreatedDate);";
            database.Open();
            var result = database.Execute(query, new { post.UserId, post.Content, post.CreatedDate });

            database.Close();
            return Ok(post);
        }

    }
}

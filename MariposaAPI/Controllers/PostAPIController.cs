using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using MariposaAPI.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MariposaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostAPIController : Controller
    {
        private readonly MySqlConnection database;
        //private readonly ILogger<PostAPIController> _logger;

        public PostAPIController(MySqlConnection mySql)
        {
            database = mySql;
        }

        [HttpGet]
        public List<PostAPIModel> GetAll()
        {
            var metadata = new List<PostAPIModel>();
            //var query = "SELECT posts.UserId, posts.Content, posts.CreatedDate, users.UserName, users.PhotoURL FROM posts JOIN users on posts.UserId = users.UserId;";
            var query = "SELECT * FROM posts;";
            database.Open();
            metadata = database.Query<PostAPIModel>(query).ToList();
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

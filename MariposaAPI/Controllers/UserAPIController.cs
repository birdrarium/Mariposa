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
    public class UserAPIController : Controller
    {
        private readonly MySqlConnection database;

        public UserAPIController(MySqlConnection mySql)
        {
            database = mySql;
        }

        [HttpGet]
        public List<UserAPIModel> GetAll()
        {
            var metadata = new List<UserAPIModel>();
            var query = "SELECT UserId, UserName, PhotoURL FROM Users";
            database.Open();
            metadata = database.Query<UserAPIModel>(query).ToList();
            database.Close();
            return metadata;
        }

        [HttpGet("{id}")]
        public ActionResult<UserAPIModel> GetById(int id)
        {
            try
            {
                var query = "SELECT * FROM posts WHERE PostId = @id";
                database.Open();
                var result = database.Query<UserAPIModel>(query, new { id });
                database.Close();
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<UserAPIModel> Post([FromBody] UserAPIModel post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var query =
                @"INSERT INTO Mariposa.users (UserId, Content, CreatedDate)
                VALUES (@UserId, @Content, @CreatedDate);";
            database.Open();
            var result = database.Execute(query, new { post.UserId, post.UserName, post.PhotoURL });

            database.Close();
            return Ok(post);
        }

    }
}

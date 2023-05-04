using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MariposaAPI.Models;
using MySqlConnector;
using Dapper;

namespace MariposaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ButterflyAPIController : ControllerBase
    {
        private readonly MySqlConnection database;
        private readonly ILogger<ButterflyAPIController> _logger;

        public ButterflyAPIController(ILogger<ButterflyAPIController> logger, MySqlConnection mySql)
        {
            _logger = logger;
            database = mySql;
        }

        [HttpGet]
        public List<ButterflyAPIModel> GetAll()
        {
            var metadata = new List<ButterflyAPIModel>();
            var query = "SELECT * from Butterflies";
            database.Open();
            metadata = database.Query<ButterflyAPIModel>(query).ToList();
            database.Close();
            return metadata;
        }

        [HttpGet("{id}")]
        public ActionResult<ButterflyAPIModel> GetById(int id)
        {
            try
            {
                var query = "SELECT * from butterflies WHERE id = @id";
                database.Open();
                var result = database.Query<ButterflyAPIModel>(query, new { id });
                database.Close();
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public ActionResult<ButterflyAPIModel> Post([FromBody] ButterflyAPIModel butterfly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var query =
                @"INSERT INTO Mariposa.butterflies (LatinName, PolishName, Description)
                VALUES (@LatinName, @PolishName, @Description);";
            database.Open();
            var result = database.Execute(query, new { butterfly.LatinName, butterfly.PolishName, butterfly.Description });

            //Check last id
            //query = "SELECT AUTO_INCREMENT FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = \"Mariposa\" AND TABLE_NAME = \"butterflies\";";
            //var inc = database.ExecuteScalarAsync(query);
            database.Close();
            return Ok(butterfly); 
        }

    }


   
}

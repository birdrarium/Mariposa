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
    public class ButterflyController : ControllerBase
    {
        private readonly MySqlConnection database;
        private readonly ILogger<ButterflyController> _logger;

        public ButterflyController(ILogger<ButterflyController> logger, MySqlConnection mySql)
        {
            _logger = logger;
            database = mySql;
        }

        [HttpGet]
        public List<ButterflyModel> GetAll()
        {
            var metadata = new List<ButterflyModel>();
            var query = "SELECT * from Butterflies";
            database.Open();
            metadata = database.Query<ButterflyModel>(query).ToList();
            database.Close();
            return metadata;
        }

        [HttpGet("{id}")]
        public ActionResult<ButterflyModel> GetById(int id)
        {
            try
            {
                var query = "SELECT * from butterflies WHERE id = @id";
                database.Open();
                var result = database.Query<ButterflyModel>(query, new { id });
                database.Close();
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public ActionResult<ButterflyModel> Post([FromBody] ButterflyModel butterfly)
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
            //query = "SELECT AUTO_INCREMENT FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = \"Mariposa\" AND TABLE_NAME = \"butterflies\";";
            //var inc = database.ExecuteScalarAsync(query);
            database.Close();
            return Ok(butterfly);
        }

    }


   
}

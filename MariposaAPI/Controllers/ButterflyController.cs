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
        public List<ButterflyModel> RunSelectQueryForButterflyModel()
        {
            var metadata = new List<ButterflyModel>();
            try 
            {
                var stm = "SELECT * from Butterflies";
                database.Open();
                metadata = database.Query<ButterflyModel>(stm).ToList();
                database.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return metadata;
        }

    }
}

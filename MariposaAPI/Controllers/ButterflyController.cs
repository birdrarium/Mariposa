using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MariposaAPI.Models;

namespace MariposaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ButterflyController : ControllerBase
    {
        private readonly ILogger<ButterflyController> _logger;

        public ButterflyController(ILogger<ButterflyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ButterflyModel GetButterflyModel()
        {
            return new ButterflyModel(1, "","","");
        }


    }
}

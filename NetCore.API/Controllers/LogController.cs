using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        
        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet("SendLog")]
        public string GetLog(string message)
        {
            _logger.LogInformation(message);
            return message;
        }

        [HttpGet("Info")]
        public IActionResult Index()
        {
            _logger.LogInformation("Logger is runnig");
            return StatusCode(202);

        }

        [HttpGet("Error")]
        public IActionResult Error()
        {
            throw new Exception("Somethinks went wrong");

        }

        [HttpGet("Res")]
        public IActionResult Res()
        {
            _logger.LogError(new Exception(), "Error");
            return null;

        }
    }
}

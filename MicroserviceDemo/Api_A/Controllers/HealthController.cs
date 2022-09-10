using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private IConfiguration _iConfiguration;

        public HealthController(IConfiguration configuration)
        {
            this._iConfiguration = configuration;
        }

        [HttpGet]
        [Route("Index")]
        public string Index()
        {
            Console.WriteLine($"This is HealthController  {this._iConfiguration["port"]} Invoke");

            return "ok"; 
        }
    }
}

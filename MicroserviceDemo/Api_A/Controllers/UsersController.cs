using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IConfiguration _iConfiguration;

        public UsersController(ILogger<UsersController> logger,IConfiguration configuration)
        {
            _logger = logger;
            this._iConfiguration = configuration;
        }
        [HttpGet]
        [Route("Get")]
        public string Get(int id)
        {
            return $"获取{id}的用户成功";
        }

        [HttpGet]
        [Route("All")]
        public string Get()
        {
            Console.WriteLine($"This is UsersController {this._iConfiguration["port"]} Invoke");

            string str = $"{ this._iConfiguration["ip"]}{ this._iConfiguration["port"]}";
            return str;
        }

    }
}

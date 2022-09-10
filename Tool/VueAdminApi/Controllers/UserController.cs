using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VueAdminApi.Model;

namespace VueAdminApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("dev-api/user/Login")]
        public string Login([FromBody]MLogn model)
        {

            var obj = new MyJsonResult()
            {
                code = 20000,
                message = "",
                data = "admin-token"
            };

            return JsonConvert.SerializeObject(obj);
        }


        [Route("dev-api/user/info")]
        public string Info(string token)
        {

            var obj = new MyJsonResult()
            {
                code = 20000,
                message = "",
                data = new
                {
                    roles = new string[] { "admin" },
                    introduction = "I am a super administrator",
                    avatar = "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif",
                    name = "Super Admin"
                }
            };

            return JsonConvert.SerializeObject(obj);
        }

        [Route("dev-api/user/logout")]
        public string logout()
        {
            var obj = new MyJsonResult()
            {
                code = 20000,
                message = "success",
            };

            return JsonConvert.SerializeObject(obj);
        }

    }
}